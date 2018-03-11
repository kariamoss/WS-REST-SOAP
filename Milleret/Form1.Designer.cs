namespace Milleret
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Villes = new System.Windows.Forms.ListBox();
            this.Stations = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelStation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Villes
            // 
            this.Villes.FormattingEnabled = true;
            this.Villes.ItemHeight = 16;
            this.Villes.Location = new System.Drawing.Point(12, 31);
            this.Villes.Name = "Villes";
            this.Villes.Size = new System.Drawing.Size(139, 276);
            this.Villes.TabIndex = 0;
            this.Villes.SelectedIndexChanged += new System.EventHandler(this.Villes_SelectedIndexChanged);
            // 
            // Stations
            // 
            this.Stations.FormattingEnabled = true;
            this.Stations.ItemHeight = 16;
            this.Stations.Location = new System.Drawing.Point(182, 31);
            this.Stations.Name = "Stations";
            this.Stations.Size = new System.Drawing.Size(212, 276);
            this.Stations.TabIndex = 1;
            this.Stations.SelectedIndexChanged += new System.EventHandler(this.Stations_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Villes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stations";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // LabelStation
            // 
            this.LabelStation.AutoSize = true;
            this.LabelStation.Location = new System.Drawing.Point(90, 319);
            this.LabelStation.Name = "LabelStation";
            this.LabelStation.Size = new System.Drawing.Size(40, 17);
            this.LabelStation.TabIndex = 4;
            this.LabelStation.Text = "Error";
            this.LabelStation.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 373);
            this.Controls.Add(this.LabelStation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Stations);
            this.Controls.Add(this.Villes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Villes;
        private System.Windows.Forms.ListBox Stations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelStation;
    }
}

