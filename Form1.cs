using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AGC_Technowizz {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
      Core.Setup();
    }



    // Error
    private void ShowError(string errorText) {
      ErrorLabel.Text = errorText;
      ErrorLabel.Visible = true;
    }

    private void HideError() {
      ErrorLabel.Text = "";
      ErrorLabel.Visible = false;
    }



    // Zone
    private void ShowZone(string zone) {
      ZoneLabel.Text = zone;
      ZoneLabel.Visible = true;
    }

    private void HideZone() {
      ZoneLabel.Text = "--";
      ZoneLabel.Visible = false;
    }



    private void SubmitHandler(object sender, EventArgs e) {
      // Check text field
      bool containerCodeEmpty = ContainerCodeTextField.Text.Trim().Length == 0;
      bool containerCodeNotOnlyNumbers = !int.TryParse(ContainerCodeTextField.Text, out int containerCode);

      if (containerCodeEmpty) {
        HideZone();
        ShowError("Textové pole nesmí být prázdné.");
      } else if (containerCodeNotOnlyNumbers) {
        HideZone();
        ShowError("Textové pole smí obsahovat pouze čísla.");
      } else {
        // containerCode ---> zone
        string carBrand = Core.GetCarBrandFromContainerCode($"{ containerCode }");
        string zone = Core.GetZoneFromCarBrand(carBrand);

        HideError();
        ShowZone(zone);
      }
    }
  }
}
