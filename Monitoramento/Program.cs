using System;
using System.Diagnostics;
using System.IO;

namespace Monitoramento
{
    internal class Program
    {
        static void Main()
        {
            string logFilePath = "registro.txt";
            int contador = 0;

            // Verifica se o arquivo de registro já existe
            if (File.Exists(logFilePath))
            {
                // Lê o conteúdo do arquivo e verifica o valor atual do contador
                string[] lines = File.ReadAllLines(logFilePath);
                if (lines.Length > 0 && lines[0].StartsWith("Total de registros identificados: #"))
                {
                    string contadorStr = lines[0].Substring("Total de registros identificados: #".Length);
                    if (int.TryParse(contadorStr, out int contadorExistente))
                    {
                        contador = contadorExistente;
                    }
                }
            }

            // Faz a verificação enquanto o programa estiver sendo executado
            while (true)
            {
                float cpuPercent = GetCpuUsage();
                float diskPercentC = GetDiskUsage("C");
                float diskPercentD = GetDiskUsage("D");

                if (cpuPercent == 100 || diskPercentC == 100 || diskPercentD == 100)
                {
                    contador++;

                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string logMessage = $"{timestamp} - [#{contador}] CPU: {cpuPercent}%, Disco C: {diskPercentC}%, Disco D: {diskPercentD}%";

                    AppendToLogFile(logMessage, logFilePath);

                    UpdateTotalRegistros(contador, logFilePath);
                }

                System.Threading.Thread.Sleep(1000); // Aguarda 1 segundo antes de verificar novamente
            }
        }

        static float GetCpuUsage()
        {
            using (PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
            {
                cpuCounter.NextValue(); // Ignora o primeiro valor

                System.Threading.Thread.Sleep(1000); // Aguarda 1 segundo para obter um valor mais preciso

                return cpuCounter.NextValue();
            }
        }

        static float GetDiskUsage(string driveLetter)
        {
            DriveInfo driveInfo = new DriveInfo(driveLetter);

            //float diskUsage = (float)(100 * (driveInfo.TotalSize - driveInfo.TotalFreeSpace) / driveInfo.TotalSize);
            int diskUsage = 100 - (int)(((float)driveInfo.AvailableFreeSpace / driveInfo.TotalSize) * 100);
            return diskUsage;
        }

        static void AppendToLogFile(string logMessage, string logFilePath)
        {
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine(logMessage);
            }
        }

        static void UpdateTotalRegistros(int contador, string logFilePath)
        {
            string[] lines = File.ReadAllLines(logFilePath);

            // Atualiza a linha do contador ou adiciona no topo se ainda não existir
            if (lines.Length > 0 && lines[0].StartsWith("Total de registros identificados: #"))
            {
                lines[0] = $"Total de registros identificados: #{contador}";
            }
            else
            {
                Array.Resize(ref lines, lines.Length + 1);
                Array.Copy(lines, 0, lines, 1, lines.Length - 1);
                lines[0] = $"Total de registros identificados: #{contador}";
            }

            File.WriteAllLines(logFilePath, lines);
        }
    }
}