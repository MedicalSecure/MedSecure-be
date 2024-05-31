using Python.Runtime;
using System.Reflection;

using System.Runtime.InteropServices;

using Microsoft.Extensions.Configuration;

namespace Prescription.Services.PredictBySymptomsService
{
    public partial class AiModule
    {
        public static IConfiguration? _configuration;

        public static void addAiModule(IConfiguration? configuration)
        {
            _configuration = configuration;
        }

        public static string? GetDiagnosisBySymptoms(List<int> symptoms, string scriptName = "predictBySymptom")
        {
            // Get the current directory path
            string ResourcesDirectory = _GetResourcesFolderPath();
            string assetsDirectory = Path.Combine(ResourcesDirectory, "assets");

            string pythonDllPath;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                /*string DllDirectory = Path.Combine(ResourcesDirectory, "Dlls");
                pythonDllPath = Path.Combine(DllDirectory, "python312.dll");*/
                pythonDllPath = "C:\\Users\\assas\\AppData\\Local\\Programs\\Python\\Python312\\python312.dll";
                if (_configuration != null)
                {
                    string? tempString = _configuration.GetValue<string>("LibrariesPath:WindowsPythonDllPath");
                    if (tempString != null) pythonDllPath = tempString;
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                pythonDllPath = "/usr/lib/x86_64-linux-gnu/libpython3.11.so";
                if (_configuration != null)
                {
                    string? tempString = _configuration.GetValue<string>("LibrariesPath:LinuxPythonDllPath");
                    if (tempString != null) pythonDllPath = tempString;
                }
            }
            else
            {
                // Handle other operating systems if needed
                throw new PlatformNotSupportedException("Operating system not supported.");
            }

            // Set the path to the Python DLL
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", pythonDllPath);

            // Initialize the Python runtime
            if (!PythonEngine.IsInitialized)
            {
                PythonEngine.Initialize();
                PythonEngine.BeginAllowThreads();
            }

            string? prediction = null;
            /*List<int> test = new List<int>(){0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
                          0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                          1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0
                            , 0, 0, 1, 0, 1, 1};*/

            using (Py.GIL())
            {
                // Import the Python modules
                dynamic sys = Py.Import("sys");

                //sys.path.append(@"directory where the python script is");
                sys.path.append(assetsDirectory);

                var sc = Py.Import(scriptName);

                var input = _ToPyListUnSafe(symptoms);
                PyObject result = sc.InvokeMethod("predictDiagnosis", new PyObject[] { input });
                if (result == null) return null;
                else prediction = result.ToString();
            }

            return prediction;
        }

        private static PyList _ToPyListUnSafe(IEnumerable<int> enumerable)
        {
            var pyList = new PyList();
            foreach (var item in enumerable)
            {
                using (var pyObject = item.ToPython())
                {
                    pyList.Append(pyObject);
                }
            }

            return pyList;
        }

        private static string _GetResourcesFolderPath()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyLocation = Path.GetDirectoryName(assembly.Location)!;

            var ServicesPath = Path.Combine(assemblyLocation, "Services");
            var PredictBySymptomsServicePath = Path.Combine(ServicesPath, "PredictBySymptomsService");
            var ResourcesPath = Path.Combine(PredictBySymptomsServicePath, "Resources");

            return ResourcesPath;
        }
    }
}