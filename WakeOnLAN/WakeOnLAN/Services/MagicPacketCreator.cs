/**
* Author: Branden Brideau
* Date: June 2022
*/

using System.Net;
using System.Net.Sockets;

namespace WakeOnLAN.Services
{
    internal static class MagicPacketCreator
    {
        /// <summary>
        /// Function to wakeup a computer on LAN.
        /// </summary>
        /// <param name="macAddress">Address of the computer to wakeup.</param>
        internal static void SendMagicPacket(string macAddress)
        {
            if (string.IsNullOrEmpty(macAddress))
            {
                return;
            }

            // Credits: https://benniroth.com/blog/2021-6-21-csharp-wake-over-lan/
            UdpClient udp = new UdpClient();

            // We need this packet to be a broadcast.
            udp.EnableBroadcast = true;

            byte[] dgram = new byte[1024];

            // generate 6 of the "magic byte"
            for (int i = 0; i < 6; i++)
            {
                dgram[i] = 255;
            }

            // Convert the mac address to bytes.
            byte[] macAddressBytes = macAddress.Split(':').Select(x => Convert.ToByte(x, 16)).ToArray();

            // Repeate the mac 16 times in the datagram.
            Span<byte> macBlock = dgram.AsSpan(6, 16 * 6);
            for (int i = 0; i < 16; i++)
            {
                macAddressBytes.CopyTo(macBlock.Slice(6 * i));
            }

            udp.Send(dgram, dgram.Length, new IPEndPoint(IPAddress.Broadcast, 0));
            udp.Close();
        }
    }
}
