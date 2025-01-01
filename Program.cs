using System;
using System.Net.Sockets;
using NModbus;

class Program
{
    static void Main(string[] args)
    {
        // Replace with the Modbus server's IP address and port
        string serverIp = "192.168.0.100";
        int port = 502;

        // Define the Modbus slave ID and register details
        byte slaveId = 1;
        ushort startAddress = 0;
        ushort numberOfRegisters = 5;

        try
        {
            Console.WriteLine("Connecting to Modbus server...");

            // Create a TCP client to connect to the Modbus server
            using TcpClient client = new TcpClient(serverIp, port);

            // Create a Modbus factory and master
            IModbusFactory factory = new ModbusFactory();
            IModbusMaster master = factory.CreateMaster(client);

            Console.WriteLine("Reading holding registers...");

            // Read holding registers
            ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numberOfRegisters);

            Console.WriteLine("Register values:");
            for (int i = 0; i < registers.Length; i++)
            {
                Console.WriteLine($"Register {startAddress + i}: {registers[i]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
