// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using CommandLine;
using Microsoft.Azure.Devices.Client;

namespace SimulatedDevice
{
    /// <summary>
    /// Command line parameters for the SimulatedDevice sample.
    /// </summary>
    internal class Parameters
    {
        public string DeviceConnectionString { get; set; } = "HostName=MedIot.azure-devices.net;DeviceId=demodevice;SharedAccessKey=V7wAavdEZ8y+r2I7EUhohPlgnfKqsLDO8AIoTFQty84=";

        [Option(
            't',
            "TransportType",
            Default = TransportType.Mqtt,
            Required = false,
            HelpText = "The transport (except HTTP) to use to communicate with the IoT hub. Possible values include Mqtt, Mqtt_WebSocket_Only, Mqtt_Tcp_Only, Amqp, Amqp_WebSocket_Only, and Amqp_Tcp_Only.")]
        public TransportType TransportType { get; set; }
    }
}
