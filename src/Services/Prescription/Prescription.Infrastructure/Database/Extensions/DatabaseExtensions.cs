using Microsoft.AspNetCore.Builder; // WebApplication

namespace Prescription.Infrastructure.Database.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //await context.Database.MigrateAsync();
        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        // Clear existing data
        await ClearDataAsync(context);

        await SeedMedicationsAsync(context);
        await SeedPatientsAsync(context);
        await SeedDoctorsAsync(context);
        await SeedSymptomsAsync(context);
        await SeedDiagnosisAsync(context);

        await SeedRegisterAsync(context);

        await SeedPrescriptionsAsync(context);
    }

    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        // Clear all data from tables
        context.Prescriptions.RemoveRange(context.Prescriptions);
        context.Register.RemoveRange(context.Register);

        context.Posology.RemoveRange(context.Posology);
        context.Comments.RemoveRange(context.Comments);
        context.Dispenses.RemoveRange(context.Dispenses);
        context.Medications.RemoveRange(context.Medications);
        context.Patients.RemoveRange(context.Patients);
        context.Doctors.RemoveRange(context.Doctors);

        context.Diagnosis.RemoveRange(context.Diagnosis);
        context.Symptoms.RemoveRange(context.Symptoms);

        // Save changes to the database
        await context.SaveChangesAsync();
    }

    private static async Task SeedMedicationsAsync(ApplicationDbContext context)
    {
        if (!await context.Medications.AnyAsync())
        {
            await context.Medications.AddRangeAsync(InitialData.Medications);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedPatientsAsync(ApplicationDbContext context)
    {
        if (!await context.Patients.AnyAsync())
        {
            await context.Patients.AddRangeAsync(InitialData.Patients);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedDoctorsAsync(ApplicationDbContext context)
    {
        if (!await context.Doctors.AnyAsync())
        {
            await context.Doctors.AddRangeAsync(InitialData.Doctors);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedPrescriptionsAsync(ApplicationDbContext context)
    {
        try
        {
            var doctors = await context.Doctors.ToListAsync();
            var medications = await context.Medications.ToListAsync();
            var symptoms = await context.Symptoms.ToListAsync();
            var diagnosis = await context.Diagnosis.ToListAsync();
            List<Register> registers = await context.Register.ToListAsync();

            // Check if there are any patients and doctors
            if (registers.Count > 0 && doctors.Count > 0)
            {
                var register = registers.First();
                var doctor = doctors.First();

                if (!await context.Prescriptions.AnyAsync())
                {
                    var newPrescription = InitialData.Prescription(register, doctor, medications, symptoms, diagnosis);

                    await context.Prescriptions.AddAsync(newPrescription);
                    await context.SaveChangesAsync();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }

    private static async Task SeedRegisterAsync(ApplicationDbContext context)
    {
        try
        {
            var patients = await context.Patients.ToListAsync();

            List<Register> register = await context.Register.ToListAsync();

            // Check if there are any patients and doctors
            if (patients.Count > 0)
            {
                var patient = patients.First();

                if (!await context.Register.AnyAsync())
                {
                    var newRegister = InitialData.Register(patient);

                    await context.Register.AddAsync(newRegister);
                    await context.SaveChangesAsync();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }

    private static async Task SeedSymptomsAsync(ApplicationDbContext context)
    {
        if (!await context.Symptoms.AnyAsync())
        {
            await context.Symptoms.AddRangeAsync(InitialData.Symptoms());
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedDiagnosisAsync(ApplicationDbContext context)
    {
        if (!await context.Diagnosis.AnyAsync())
        {
            await context.Diagnosis.AddRangeAsync(InitialData.DiagnosisInitialData());
            await context.SaveChangesAsync();
        }
    }

    /*

            private static async Task SeedCommentsAsync(ApplicationDbContext context)
        {
            if (!await context.Comments.AnyAsync())
            {
                await context.Comments.AddRangeAsync(InitialData.Comments);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedDispensesAsync(ApplicationDbContext context)
        {
            if (!await context.Dispenses.AnyAsync())
            {
                await context.Dispenses.AddRangeAsync(InitialData.Dispenses);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedPosologyAsync(ApplicationDbContext context)
        {
            if (!await context.Posology.AnyAsync())
            {
                await context.Posology.AddRangeAsync(InitialData.posology);
                await context.SaveChangesAsync();
            }
        }*/
}