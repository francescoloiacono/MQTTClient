namespace MQTTprj
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_log = new System.Windows.Forms.TextBox();
            this.btn_publish = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.topic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.endpoint = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_subscribe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.SystemColors.Window;
            this.txt_log.Location = new System.Drawing.Point(37, 242);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(730, 186);
            this.txt_log.TabIndex = 26;
            // 
            // btn_publish
            // 
            this.btn_publish.Location = new System.Drawing.Point(678, 140);
            this.btn_publish.Name = "btn_publish";
            this.btn_publish.Size = new System.Drawing.Size(75, 23);
            this.btn_publish.TabIndex = 25;
            this.btn_publish.Text = "Publish";
            this.btn_publish.UseVisualStyleBackColor = true;
            this.btn_publish.Click += new System.EventHandler(this.btn_publish_Click);
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(126, 179);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(427, 20);
            this.message.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "MQTT Message:";
            // 
            // topic
            // 
            this.topic.Location = new System.Drawing.Point(126, 142);
            this.topic.Name = "topic";
            this.topic.Size = new System.Drawing.Size(427, 20);
            this.topic.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "MQTT Topic:";
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(678, 53);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_disconnect.TabIndex = 20;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(126, 55);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(81, 20);
            this.port.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "MQTT Port:";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(678, 22);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 17;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // endpoint
            // 
            this.endpoint.Location = new System.Drawing.Point(126, 24);
            this.endpoint.Name = "endpoint";
            this.endpoint.Size = new System.Drawing.Size(427, 20);
            this.endpoint.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "MQTT Endpoint:";
            // 
            // btn_subscribe
            // 
            this.btn_subscribe.Location = new System.Drawing.Point(678, 172);
            this.btn_subscribe.Name = "btn_subscribe";
            this.btn_subscribe.Size = new System.Drawing.Size(75, 23);
            this.btn_subscribe.TabIndex = 27;
            this.btn_subscribe.Text = "Subscribe";
            this.btn_subscribe.UseVisualStyleBackColor = true;
            this.btn_subscribe.Click += new System.EventHandler(this.btn_subscribe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_subscribe);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.btn_publish);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.topic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.endpoint);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Button btn_publish;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox topic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox endpoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_subscribe;
    }
}

