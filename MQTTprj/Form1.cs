using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQTTnet.Client;
using MQTTnet.Server;
using MQTTnet;          //version 3.0.16
using Newtonsoft.Json;
using Serilog;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Protocol;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using System.Net;
using System.CodeDom;
using System.Text.RegularExpressions;   //for Regex Class
using static System.Net.Mime.MediaTypeNames;
using System.Timers;
//using System.ComponentModel.Composition.Primitives;
using MQTTnet.Formatter;
using MQTTnet.Client.Subscribing;
using System.Runtime.Remoting.Contexts;

namespace MQTTprj
{
    public partial class Form1 : Form
    {
        public Regex ipRegex = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
        public Regex hostnameRegex = new Regex(@"^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-_]*[a-zA-Z0-9])\.)*([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-_]*[a-zA-Z0-9])$");
        //log section string 
        private StringBuilder logMessages = new StringBuilder();



        private IMqttClient _mqttClient;
      /*  IMqttClientOptions options = new MqttClientOptionsBuilder()
                        //.WithTcpServer(endpoint,port)            
                        .WithCredentials("merlin", "mqttclient")
                        .WithProtocolVersion(MqttProtocolVersion.V311)
                        // .WithClientId(Guid.NewGuid().ToString())
                        .WithClientId("Merlin")
                        .Build();
*/

        #region Handlers

        public void OnConnected(MqttClientConnectedEventArgs obj)
        {
            if (txt_log.InvokeRequired)
            {
                txt_log.Invoke(new Action(() => txt_log.Text = logMessages.Append("Successfully connected." + "\r\n").ToString()));
            }
            else
            {
              //  logMessages.Append("Successfully connected." + "\r\n");
                txt_log.Text = logMessages.ToString();
            }

        }
        public void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {
            if (txt_log.InvokeRequired)
            {
                txt_log.Invoke(new Action(() => txt_log.Text = logMessages.Append("Couldn't connect to broker." + "\r\n").ToString()));
            }
            else
            {
                //    logMessages.Append("Couldn't connect to broker."+ "\r\n");
                txt_log.Text = logMessages.ToString();
            }
        }

        public void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {

            if (txt_log.InvokeRequired)
            {
                txt_log.Invoke(new Action(() => txt_log.Text = logMessages.Append("Successfully disconnected." + "\r\n").ToString()));
            }
            else
            {
                //  logMessages.Append("Successfully disconnected." + "\r\n");
                txt_log.Text = logMessages.ToString();
            }
        }



        #endregion


        //check if the string is such as "example.com"
        bool check_hostname(string endpoint)
        {
            return hostnameRegex.IsMatch(endpoint);
        }
        //check if the string is such as "192.168.0.1"
        bool check_ip(string endpoint)
        {
            return ipRegex.IsMatch(endpoint);
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                if(_mqttClient != null && _mqttClient.IsConnected)
                {
                    AddLog($"Client already connected to {this.endpoint.Text}:{int.Parse(this.port.Text)}");

                }
                else
                {
                    //clear log
                    logMessages.Clear();
                    txt_log.Text = "";
                    //check if the port is a number and the address are valid
                    if (int.TryParse(port.Text, out int port_num) && (check_hostname(endpoint.Text) || check_ip(endpoint.Text)))
                    {
                        if (port_num < 1 || port_num > 65535)
                        {
                            throw new ArgumentOutOfRangeException("Input Error: port must be inside (1 - 65535) range");
                        }
                        var factory = new MqttFactory();
                        _mqttClient = factory.CreateMqttClient();

                        var endpoint = this.endpoint.Text;
                        var port = int.Parse(this.port.Text);

                        IMqttClientOptions options = new MqttClientOptionsBuilder()
                              .WithTcpServer(endpoint, port)
                              .WithCredentials("merlin", "mqttclient")
                              .WithProtocolVersion(MqttProtocolVersion.V311)
                              // .WithClientId(Guid.NewGuid().ToString())
                              .WithClientId("Merlin")
                              .Build();

                        if (!_mqttClient.IsConnected)
                        {
                            try
                            {
                                _mqttClient.ConnectAsync(options).GetAwaiter().GetResult();
                                if (_mqttClient.IsConnected)
                                {
                                    AddLog($"Client successfully connected to {endpoint}:{port}");
                                }
                            }
                            catch (Exception)
                            {
                                AddLog($"Broker doesn't respond to {endpoint}:{port} ");
                            }

                        }
                        else
                        {
                            AddLog($"Client already connected to {endpoint}:{port}");
                        }
                    }
                    else
                    {
                        throw new FormatException("Input Error: the endpoint or port are not valid, check if they are correct and retry.");
                    }
                }
               

            }
            catch (FormatException ex)
            {
                logMessages.Append(ex.Message + "\r\n");
                txt_log.Text = logMessages.ToString();

            }
            catch (ArgumentOutOfRangeException ex)
            {
                logMessages.Append(ex.Message + "\r\n");
                txt_log.Text = logMessages.ToString();
            }
            catch (Exception ex)
            {
                logMessages.Append(ex.Message + "\r\n");
                txt_log.Text = logMessages.ToString();
            }


        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            logMessages.Clear();
            txt_log.Text = "";
            if (_mqttClient.IsConnected)
            {
                _mqttClient?.DisconnectAsync().GetAwaiter().GetResult();
                if (!_mqttClient.IsConnected)
                {
                    AddLog("Disconnected");
                }
            }
            else
            {
                AddLog("No Client was started");
            }
            

        }

        private void btn_publish_Click(object sender, EventArgs e)
        {
            if (_mqttClient.IsConnected) {
                var topic = this.topic.Text;
                var message = this.message.Text;

                var mqttMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(message)
                    .WithExactlyOnceQoS()
                    .WithRetainFlag()
                    .Build();

                _mqttClient.PublishAsync(mqttMessage).GetAwaiter().GetResult();

                AddLog($"Published message to topic '{topic}': {message}");
            }
            else
            {
                AddLog("Before connect a client to a broker");
            }
        }
        private void AddLog(string message)
        {
            this.txt_log.AppendText($"[{DateTime.Now}] {message}{Environment.NewLine}");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mqttClient?.DisconnectAsync().GetAwaiter().GetResult();
        }


        private void btn_subscribe_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (_mqttClient.IsConnected && _mqttClient != null)
                {
                    //setting up the handler
                    _mqttClient.UseApplicationMessageReceivedHandler(session =>
                    {
                        var json = Encoding.UTF8.GetString(session.ApplicationMessage.Payload);
                        BeginInvoke(new Action(() =>
                        {
                            txt_log.AppendText("Received JSON data: " + json + Environment.NewLine);
                        }));

                    });
                    //set up topic filter
                    var topic = this.topic.Text;
                    var topicfilter = new MqttTopicFilterBuilder().WithTopic(topic).Build();
                    //verifing the subscribe was successful
                    MQTTnet.Client.Subscribing.MqttClientSubscribeResult sub_res = _mqttClient.SubscribeAsync(topicfilter).GetAwaiter().GetResult();
                    if (sub_res.Items[0].ResultCode == MqttClientSubscribeResultCode.GrantedQoS1 || sub_res.Items[0].ResultCode == MqttClientSubscribeResultCode.GrantedQoS2 || sub_res.Items[0].ResultCode == MqttClientSubscribeResultCode.GrantedQoS0)
                    {
                       
                        AddLog("Successfully subscribed to topic. " + topic);
                        
                    }
                    else
                    {
                        AddLog("Failed to subscribe to topic. " + topic);
                    }
                    
                }
                else
                {
                    //throw new NullReferenceException("Before specify a client to a broker");
                    AddLog("Before connect a client to a broker");
                }
            }
            catch(NullReferenceException) 
            {
                AddLog("Before connect a client to a broker");
            }
        }
    }
}
