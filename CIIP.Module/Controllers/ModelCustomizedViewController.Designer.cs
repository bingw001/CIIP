﻿namespace CIIP.Module.Controllers
{
    partial class ModelCustomizedViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.更新模型 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // 更新模型
            // 
            this.更新模型.Caption = "更新模型";
            this.更新模型.Category = "Tools";
            this.更新模型.ConfirmationMessage = null;
            this.更新模型.Id = "更新模型";
            this.更新模型.ToolTip = null;
            this.更新模型.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.更新模型_Execute);
            // 
            // ModelCustomizedViewController
            // 
            this.Actions.Add(this.更新模型);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction 更新模型;
    }
}
