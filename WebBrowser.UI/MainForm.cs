﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser;
using WebBrowser = System.Windows.Forms.WebBrowser;

namespace WebBrowser.UI
{
     public partial class GromBrowser : Form
     {
          private ArrayList tabList = new ArrayList();
          private ArrayList webList = new ArrayList();
          private int currentTab = 0;

          public GromBrowser()
          {
               InitializeComponent();
               windowTabs.Controls.Clear();
               CreateNewTab();
               var webPage = GetCurrentBrowser();
          }

          // Creates a new tab with a browser object set at DockStyle.Fill.
          private void CreateNewTab()
          {
               var newPage = new TabPage("Loading");
               tabList.Add(newPage);
               windowTabs.TabPages.Add(newPage);
               currentTab++;
               var webPage = new System.Windows.Forms.WebBrowser();
               webList.Add(webPage);
               webPage.Parent = newPage;
               webPage.Dock = DockStyle.Fill;
          }

          // Focus on current tab.
          private System.Windows.Forms.WebBrowser GetCurrentBrowser()
          {
               var thisTab = windowTabs.SelectedTab;
               var thisPage = (System.Windows.Forms.WebBrowser)webList[tabList.IndexOf(thisTab)];
               return thisPage;
          }

          // Tab name update.
          private void UpdateName(TabPage tabIn)
          {
               if (tabIn == null) throw new ArgumentNullException(nameof(tabIn));
               var thisTab = tabIn;
               var thisPage = (System.Windows.Forms.WebBrowser) webList[tabList.IndexOf(this.currentTab)];
               thisTab.Text = thisPage.Document != null ? thisPage.DocumentTitle : "Loading";
          }

          // Updates all names on all tabs.
          private void UpdateTabNames()
          {
               foreach (TabPage tab in windowTabs.TabPages)
               {
                    UpdateName(tab);
               }
          }




          /**
           * This function called to close the browser.
           */
          private void ExitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
          {
               this.Close();
          }

          private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
          {
               MessageBox.Show(
                    "Welcome to the best browser ever built in this office. It is brought to you by Luis Cortez (lac0084@auburn.edu). I hope you enjoy your stay.");
          }

          private void ToolStripButton1_Click(object sender, EventArgs e)
          {

          }

          /**
           * This function will allow us to hit enter from the address text box and go to web page entered.
           */
          private void ToolStripSpringTextBox1_KeyPress(object sender, KeyPressEventArgs e)
          {
               if (e.KeyChar == (char)ConsoleKey.Enter)
               {
                    NavigateToPage();
                    urlTextBox.Focus();
               }
          }

          private void Go_Click(object sender, EventArgs e)
          {
               NavigateToPage();
          }

          /**
          * Navigation function
          */
          private void NavigateToPage()
          {
               // Displays loading on status label.
               toolStripStatusLabel1.Text = "Page Loading";

          }


          // Will come back to this progress bar : once navigation restored
          private void WebBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
          {
               /**
                * This if statement will take care of a divide by zero error.
                */
               if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
               {
                    if (toolStripProgressBar1.ProgressBar != null)
                         toolStripProgressBar1.ProgressBar.Value = (int) (e.CurrentProgress * 100 / e.MaximumProgress);
               }
          }

          //Once i can get a valid name for webBrowser instance than I can turn this on
          private void PrintPageToolStripMenuItem_Click(object sender, EventArgs e)
          {
               //webBrowser1.ShowPrintPreviewDialog();
          }



















          private void ManageHistoryToolStripMenuItem_Click(object sender, EventArgs e)
          {
               var historyForm = new HistoryManagerForm();
               historyForm.ShowDialog();
          }

          public void ManageBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
          {
               var bookmarkForm = new BookmarkManagerForm();
               bookmarkForm.ShowDialog();
          }

          private void CloseCurrentTabToolStripMenuItem_Click_1(object sender, EventArgs e)
          {
               windowTabs.TabPages.Remove(windowTabs.SelectedTab);
          }

          private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
          {

          }
     }


}
