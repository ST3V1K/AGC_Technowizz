
namespace AGC_Technowizz {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && ( components != null )) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.ContainerCodeTextField = new System.Windows.Forms.TextBox();
      this.ContainerCodeLabel = new System.Windows.Forms.Label();
      this.SubmitButton = new System.Windows.Forms.Button();
      this.ZoneLabel = new System.Windows.Forms.Label();
      this.ErrorLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // ContainerCodeTextField
      // 
      this.ContainerCodeTextField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ContainerCodeTextField.Location = new System.Drawing.Point(134, 103);
      this.ContainerCodeTextField.Name = "ContainerCodeTextField";
      this.ContainerCodeTextField.Size = new System.Drawing.Size(384, 22);
      this.ContainerCodeTextField.TabIndex = 0;
      // 
      // ContainerCodeLabel
      // 
      this.ContainerCodeLabel.AutoSize = true;
      this.ContainerCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ContainerCodeLabel.Location = new System.Drawing.Point(289, 71);
      this.ContainerCodeLabel.Name = "ContainerCodeLabel";
      this.ContainerCodeLabel.Size = new System.Drawing.Size(72, 16);
      this.ContainerCodeLabel.TabIndex = 1;
      this.ContainerCodeLabel.Text = "Kód palety";
      // 
      // SubmitButton
      // 
      this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SubmitButton.Location = new System.Drawing.Point(134, 176);
      this.SubmitButton.Name = "SubmitButton";
      this.SubmitButton.Size = new System.Drawing.Size(384, 81);
      this.SubmitButton.TabIndex = 2;
      this.SubmitButton.Text = "Zadat";
      this.SubmitButton.UseVisualStyleBackColor = true;
      this.SubmitButton.Click += new System.EventHandler(this.SubmitHandler);
      // 
      // ZoneLabel
      // 
      this.ZoneLabel.AutoSize = true;
      this.ZoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ZoneLabel.Location = new System.Drawing.Point(235, 404);
      this.ZoneLabel.Name = "ZoneLabel";
      this.ZoneLabel.Size = new System.Drawing.Size(175, 108);
      this.ZoneLabel.TabIndex = 3;
      this.ZoneLabel.Text = "XY";
      this.ZoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.ZoneLabel.Visible = false;
      // 
      // ErrorLabel
      // 
      this.ErrorLabel.AutoSize = true;
      this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.ErrorLabel.Location = new System.Drawing.Point(131, 128);
      this.ErrorLabel.Name = "ErrorLabel";
      this.ErrorLabel.Size = new System.Drawing.Size(233, 16);
      this.ErrorLabel.TabIndex = 4;
      this.ErrorLabel.Text = "Textové pole nesmí být prázdné.";
      this.ErrorLabel.Visible = false;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(650, 685);
      this.Controls.Add(this.ErrorLabel);
      this.Controls.Add(this.ZoneLabel);
      this.Controls.Add(this.SubmitButton);
      this.Controls.Add(this.ContainerCodeLabel);
      this.Controls.Add(this.ContainerCodeTextField);
      this.Name = "Form1";
      this.Text = "Přiřazovač zóny";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox ContainerCodeTextField;
    private System.Windows.Forms.Label ContainerCodeLabel;
    private System.Windows.Forms.Button SubmitButton;
    private System.Windows.Forms.Label ZoneLabel;
    private System.Windows.Forms.Label ErrorLabel;
  }
}

