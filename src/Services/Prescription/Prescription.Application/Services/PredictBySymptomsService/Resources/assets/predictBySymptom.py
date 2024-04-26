import numpy as np # linear algebra
import pickle
import os
import sys


def predictDiagnosis(inputArray):
    script_dir = os.path.dirname(os.path.abspath(__file__))

    # Load the model from the same directory as the script
    model_path = os.path.join(script_dir, 'knn_model.pkl')
    loaded_model = pickle.load(open(model_path, 'rb'))

    # Use the loaded model for prediction
   # inputArray=[0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1]

    reshaped_data = np.array([inputArray]).reshape(1, -1)

    new_prediction = loaded_model.predict(reshaped_data)

    print(f"Predicted label: {new_prediction[0]}")
    
    return new_prediction[0]
