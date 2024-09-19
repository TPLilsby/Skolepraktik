import warnings
import sys
import cv2
import os
import webbrowser
from pyzbar.pyzbar import decode

# Undertrykke advarsler
warnings.filterwarnings("ignore")

# Configuration file name
CONFIG_FILE = 'barcode_folders.txt'

class suppress_output:
    """Kontekstmanager til midlertidigt at undertrykke konsoloutput."""
    def __enter__(self):
        self._original_stdout = sys.stdout
        self._original_stderr = sys.stderr
        sys.stdout = open(os.devnull, 'w')
        sys.stderr = open(os.devnull, 'w')

    def __exit__(self, exc_type, exc_val, exc_tb):
        sys.stdout.close()
        sys.stderr.close()
        sys.stdout = self._original_stdout
        sys.stderr = self._original_stderr

def read_barcodes_from_file(filename):
    """Read barcodes and URLs from the configuration file."""
    barcode_url_map = {}
    if os.path.exists(filename):
        with open(filename, 'r') as file:
            for line in file:
                barcode, url = line.strip().split('|')
                barcode_url_map[barcode] = url
    return barcode_url_map

def update_barcodes_file(filename, barcode, url):
    """Update the configuration file with a new barcode and URL."""
    with open(filename, 'a') as file:
        file.write(f"{barcode}|{url}\n")

def open_url(url):
    """Open the specified URL."""
    if url.startswith(('http://', 'https://')):
        webbrowser.open(url)
    else:
        print("Invalid URL:", url)

def main():
    # Initialize camera
    camera = cv2.VideoCapture(0)
    barcode_url_map = read_barcodes_from_file(CONFIG_FILE)

    print("Scanning barcodes...")

    while True:
        # Capture image from the camera
        ret, frame = camera.read()
        if not ret:
            print("Camera error")
            break

        # Undertrykke output under dekodning og visning
        with suppress_output():
            barcodes = decode(frame)
            cv2.imshow('Camera', frame)

        for barcode in barcodes:
            barcode_data = barcode.data.decode('utf-8')
            print(f"Scanned barcode: {barcode_data}")

            # If the barcode is found in the configuration, open the URL
            if barcode_data in barcode_url_map:
                url = barcode_url_map[barcode_data]
                open_url(url)
            else:
                print("Barcode not found in configuration. Adding new entry...")
                new_url = input("Enter the URL for the new barcode: ")
                update_barcodes_file(CONFIG_FILE, barcode_data, new_url)
                barcode_url_map[barcode_data] = new_url
                open_url(new_url)

        # Exit the program if 'q' is pressed
        if cv2.waitKey(1) & 0xFF == ord('q'):
            break

    # Release camera and close all windows
    camera.release()
    cv2.destroyAllWindows()

if __name__ == "__main__":
    main()
    input("Press Enter to exit the program...")