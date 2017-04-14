using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace kinect
{
    static class Serveur
    {
        private static StreamWriter writer;
        public static void ServerThread()
        {
            NamedPipeServerStream pipeServer =
                new NamedPipeServerStream("testpipe", PipeDirection.InOut, 2);

            int threadId = Thread.CurrentThread.ManagedThreadId;

            // Wait for a client to connect
            pipeServer.WaitForConnection();

            Console.WriteLine("Client connected on thread[{0}].", threadId);
            try
            {
                // Read the request from the client. Once the client has
                // written to the pipe its security token will be available.

                writer = new StreamWriter(pipeServer);

                // Verify our identity to the connected client using a
                // string that the client anticipates.

                //writer.WriteLine("x main droite = ");
                //string filename = ss.ReadString();

                // Read in the contents of the file while impersonating the client.
                /*ReadFileToStream fileReader = new ReadFileToStream(ss, filename);

                // Display the name of the user we are impersonating.
                Console.WriteLine("Reading file: {0} on thread[{1}] as user: {2}.",
                    filename, threadId, pipeServer.GetImpersonationUserName());
                pipeServer.RunAsClient(fileReader.Start);*/
            }
            // Catch the IOException that is raised if the pipe is broken
            // or disconnected.
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
            //pipeServer.Close();
        }

        public static void WriteInPipe(string msg)
        {
            writer.WriteLine(msg);
        }
    }
}
