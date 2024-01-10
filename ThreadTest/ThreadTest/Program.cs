using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.IO;
using System.Net;

class Program
{
    #region First example
    /*
    // Method that prints numbers in a separate thread
    static void PrintNumbers()
    {
        // Loop from 1 to 5
        for (int i = 1; i <= 5; i++)
        {
            // Print the current number in the thread
            Console.WriteLine($"Thread: {i}");

            // Pause the thread for 1000 milliseconds (1 second)
            Thread.Sleep(1000);
        }
    }
    */
    #endregion

    #region Second example
    /*
    // Method that calculates the sum of square roots of numbers within a range
    static double Calculate(int start, int end)
    {
        double result = 0;

        // Loop through the numbers from 'start' to 'end'
        for (int i = start; i <= end; i++)
        {
            // Add the square root of the current number to the result
            result += Math.Sqrt(i);
        }

        // Return the total sum of square roots within the range
        return result;
    }
    */
    #endregion

    #region Fourth example
    /*
    // Method that calculates the sum of square roots of numbers within a range
    static double Calculate(int start, int end)
    {
        double result = 0;

        // Loop through the numbers from 'start' to 'end'
        for (int i = start; i <= end; i++)
        {
            // Add the square root of the current number to the result
            result += Math.Sqrt(i);
        }

        // Return the total sum of square roots within the range
        return result;
    }
    */
    #endregion

    #region Fifth example
    /*
    // Initialize a SemaphoreSlim with an initial count of 1
    static SemaphoreSlim semaphore = new SemaphoreSlim(1);

    // Method simulating work performed by multiple threads
    static void DoWork(int id)
    {
        Console.WriteLine($"Thread: {id} waiting on permission.");

        // Wait to acquire the semaphore
        semaphore.Wait();

        Console.WriteLine($"Thread {id} has been granted permission and is doing work.");

        // Simulate work by pausing the thread for 2000 milliseconds (2 seconds)
        Thread.Sleep(2000);

        Console.WriteLine($"Thread {id} has completed and is releasing permission.");

        // Release the semaphore
        semaphore.Release();
    }
    */
    #endregion

    #region Sixth example
    static async Task DownloadPart(HttpClient httpClient, string url, long start, long end, FileStream fileStream)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Range = new System.Net.Http.Headers.RangeHeaderValue(start, end);

        using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            await contentStream.CopyToAsync(fileStream);
        }
    }
    #endregion


    #region example 1, 2, 3, 4, 5
    //static void Main(string[] args)
    //{
    #region First example
    /*
    // Create a new thread to execute the PrintNumbers method concurrently
    Thread thread = new Thread(PrintNumbers);
    thread.Start();

    // Loop through characters from 'a' to 'g' in the main thread
    for (char c = 'a'; c <= 'g'; c++)
    {
        // Print the current character in the main thread
        Console.WriteLine($"Main Thread: {c}");

        // Pause the main thread for 500 milliseconds
        Thread.Sleep(500);
    }
    */
    #endregion

    #region Second example
    /*
    // Define the total number of iterations
    int n = 10000000;

    // Start two tasks to calculate in parallel, each operating on a different range
    Task<double> task1 = Task.Run(() => Calculate(1, n / 2)); // First half of the range
    Task<double> task2 = Task.Run(() => Calculate((n / 2) + 1, n)); // Second half of the range

    // Wait for both tasks to complete
    Task.WaitAll(task1, task2);

    // Combine the results from both tasks
    double result = task1.Result + task2.Result;

    // Print the final result of the calculation
    Console.WriteLine($"The result of the calculation is: {result}");
    */
    #endregion

    #region Third example
    /*
    // Define an array of numbers
    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    // Perform parallel processing on the array using Parallel.ForEach
    Parallel.ForEach(numbers, num =>
    {
        // Calculate and print the square of each number in parallel
        Console.WriteLine($"The Square of {num} is {num * num}");
    });
    */
    #endregion


    #region Fourth example
    /*
    // Start a task to perform a calculation in parallel
    Task<double> calculateTask = Task.Factory.StartNew(() => Calculate(1, 10000000));

    // Retrieve the result from the task
    double result = calculateTask.Result;

    // Display the calculated result
    Console.WriteLine($"The result is: {result}");
    */
    #endregion


    #region Fifth example
    /*
    // Loop that creates and starts tasks to simulate work by multiple threads
    for (int i = 1; i <= 5; i++)
    {
        // Start a new task using Task.Run to simulate work performed by different threads
        Task.Run(() => DoWork(i));

        // Waits for user input before starting the next task
        Console.ReadLine();
    }
    */
    #endregion

    //}
    #endregion

    #region Sixth example
    static async Task Main(string[] args)
     {
            string fileUrl = @"C:\\Users\\zbctoli\\Documents\\GitHub\\Skolepraktik\\ThreadTest\\ThreadTest\\TextFiles\\TextFile.txt\";
            string destinationFilePath = @"C:\\Users\\zbctoli\\Documents\\GitHub\\Skolepraktik\\ThreadTest\\ThreadTest\\Destination\";
            int numThreads = 4; // Number of threads to use

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Failed to download the file. Status code: " + response.StatusCode);
                    return;
                }

                long fileSize = response.Content.Headers.ContentLength ?? 0;
                Console.WriteLine("File size: " + fileSize);

                // Create file streams for each thread
                FileStream[] fileStreams = new FileStream[numThreads];
                for (int i = 0; i < numThreads; i++)
                {
                    fileStreams[i] = new FileStream(destinationFilePath + ".part" + i, FileMode.Create);
                }

                long blockSize = fileSize / numThreads;

                // Start threads for downloading parts of the file
                Task[] downloadTasks = new Task[numThreads];
                for (int i = 0; i < numThreads; i++)
                {
                    long start = blockSize * i;
                    long end = (i == numThreads - 1) ? fileSize - 1 : blockSize * (i + 1) - 1;

                    downloadTasks[i] = DownloadPart(httpClient, fileUrl, start, end, fileStreams[i]);
                }

                await Task.WhenAll(downloadTasks);

                // Combine downloaded parts into one file
                using (var combinedFileStream = new FileStream(destinationFilePath, FileMode.Create))
                {
                    for (int i = 0; i < numThreads; i++)
                    {
                        byte[] buffer = File.ReadAllBytes(destinationFilePath + ".part" + i);
                        combinedFileStream.Write(buffer, 0, buffer.Length);
                        File.Delete(destinationFilePath + ".part" + i);
                    }
                }

                Console.WriteLine("Download complete.");
            }
    }
    #endregion
}