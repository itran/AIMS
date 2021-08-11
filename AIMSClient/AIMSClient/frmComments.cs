using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using AIMS.BLL;
using System.IO;

namespace AIMSClient
{
    public partial class frmComments : Form
    {
        //private NetSpell.SpellChecker.Spelling spelling;
        //private NetSpell.SpellChecker.Dictionary.WordDictionary wordDictionary;

        protected string patientNo = string.Empty;
        private Notes notesBLL;
        
        public frmComments()
        {
            InitializeComponent();
        }

        public frmComments(string patientFileNo)
        {
            InitializeComponent();
            patientNo = patientFileNo;
        }

        private string _userID = "";
        private string _patientSubFileId = "";

        private string _noteTypeCD = "";
        private Int64 _noteID = 0;
        private Int64 _patietSubFileId = 0;
        
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string PatientSubFileId
        {
            get { return _patientSubFileId; }
            set { _patientSubFileId = value; }
        }

        public Int64 NoteID
        {
            get { return _noteID; }
            set { _noteID = value; }
        }

        public Int64 PatietSubFileId
        {
            get { return _noteID; }
            set { _noteID = value; }
        }
        
        public string NoteTypeCode
        {
            get { return _noteTypeCD; }
            set { _noteTypeCD = value; }
        }
	
        private void frmComments_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 180);
            //e.Graphics.FillRectangle(lb, this.ClientRectangle);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmComments_Load(object sender, EventArgs e)
        {
            notesBLL = new Notes();
            DataTable dtNoteTypes = notesBLL.GetNoteTypes();
            if (dtNoteTypes.Rows.Count > 0)
            {
                cboNoteType.DataSource = dtNoteTypes;
                cboNoteType.DisplayMember = "Note_Type_Desc";
                cboNoteType.ValueMember = "Note_Type_ID";
            }
            if (!NoteID.Equals(0))
            {
                DataTable dtNoteInfo = notesBLL.GetNote(NoteID);
                if (!dtNoteInfo.Rows.Count.Equals(0))
                {
                    txtCommentText.Text = dtNoteInfo.Rows[0]["NOTES"].ToString();
                    cboNoteType.SelectedValue = dtNoteInfo.Rows[0]["NOTE_TYPE_ID"];
                    btnSave.Text = "Save";
                }
            }

            int rowCnt = 0;
            foreach (DataRow  drNoteType in dtNoteTypes.Rows)
            {
                if (dtNoteTypes.Rows[rowCnt]["NOTE_TYPE_CD"].Equals(NoteTypeCode))
                {
                    cboNoteType.SelectedValue = dtNoteTypes.Rows[rowCnt]["NOTE_TYPE_ID"];
                    cboNoteType.Enabled = false;
                }
                rowCnt++;
            }
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                btnSave.Enabled = false;
                if (ValidateControls())
                {
                    if (chkSpellCheck.Checked) { SpellCheck(); }

                    Int32 sNoteType = System.Convert.ToInt32(cboNoteType.SelectedValue);
                    notesBLL = new Notes();
                    notesBLL.SavePatientNotes(patientNo, UserID, txtCommentText.Text, sNoteType, NoteID);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                btnSave.Enabled = true;
            }
        }
        
        /// <summary>
        /// This method validates that all the required values have been provided.
        /// </summary>
        /// <returns></returns>
        private bool ValidateControls()
        {
            bool returnVal = true;
            try
            {
                errDesription.Clear();

                if (cboNoteType.SelectedItem == null)
                {
                    errDesription.SetError(cboNoteType, "Please select a Note Type");
                    cboNoteType.Focus();
                    btnSave.Enabled = true;
                    returnVal = false;
                    return returnVal;
                }

                if (cboNoteType.SelectedItem != null && (cboNoteType.Text == ""))
                {
                    errDesription.SetError(cboNoteType, "Please select a Note Type");
                    cboNoteType.Focus();
                    btnSave.Enabled = true;
                    returnVal = false;
                    return returnVal;
                }

                if (txtCommentText.Text.Trim().Length == 0)
                {
                    errDesription.SetError(txtCommentText, "Please enter text before clicking the Add button");
                    txtCommentText.Focus();
                    btnSave.Enabled = true;
                    returnVal = false;
                }
            }
            catch (Exception)
            {                
                throw;
            }
            return returnVal;
        }

        private void txtCommentText_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkSpellCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void spelling_DeletedWord(object sender, NetSpell.SpellChecker.SpellingEventArgs e)
        {
            
            int start = this.txtCommentText.SelectionStart;
            int length = this.txtCommentText.SelectionLength;

            this.txtCommentText.Select(e.TextIndex, e.Word.Length);
            this.txtCommentText.SelectedText = "";

            if (start > this.txtCommentText.Text.Length)
                start = this.txtCommentText.Text.Length;

            if ((start + length) > this.txtCommentText.Text.Length)
                length = 0;

            this.txtCommentText.Select(start, length);
        }

        private void spelling_ReplacedWord(object sender, NetSpell.SpellChecker.ReplaceWordEventArgs e)
        {
            int start = this.txtCommentText.SelectionStart;
            int length = this.txtCommentText.SelectionLength;

            this.txtCommentText.Select(e.TextIndex, e.Word.Length);
            this.txtCommentText.SelectedText = e.ReplacementWord;

            if (start > this.txtCommentText.Text.Length)
                start = this.txtCommentText.Text.Length;

            if ((start + length) > this.txtCommentText.Text.Length)
                length = 0;

            this.txtCommentText.Select(start, length);
        }

        private void spelling_EndOfText(object sender, System.EventArgs e)
        {
            Int32 sNoteType = System.Convert.ToInt32(cboNoteType.SelectedValue);
            notesBLL = new Notes();
            notesBLL.SavePatientNotes(patientNo, UserID, txtCommentText.Text, sNoteType, NoteID);
            txtCommentText.Text = txtCommentText.Text;

            this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void SpellChecker_MisspelledWord(object sender, NetSpell.SpellChecker.SpellingEventArgs e)
        {
            //Console.WriteLine(e.Word.ToString());
        }


        private void SpellCheck()
        {
            try
            {
                Word.Application app = new Word.Application();
                int errors = 0;
                if (txtCommentText.Text.Length > 0)
                {
                    app.Visible = false;

                    // Setting these variables is comparable to passing null to the function.
                    // This is necessary because the C# null cannot be passed by reference.
                    object template = Missing.Value;
                    object newTemplate = Missing.Value;
                    object documentType = Missing.Value;
                    object visible = true;

                    Word._Document doc1 = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);

                    doc1.Words.First.InsertBefore(txtCommentText.Text);
                    Word.ProofreadingErrors spellErrorsColl = doc1.SpellingErrors;
                    errors = spellErrorsColl.Count;
                    doc1.Activate();
                    
                    object optional = Missing.Value;

                    doc1.CheckSpelling(
                        ref optional, ref optional, ref optional, ref optional, ref optional, ref optional,
                        ref optional, ref optional, ref optional, ref optional, ref optional, ref optional);

                    object first = 0;
                    object last = doc1.Characters.Count - 1;
                    txtCommentText.Text = doc1.Range(ref first, ref last).Text;
                }

                object saveChanges = false;
                object originalFormat = Missing.Value;
                object routeDocument = Missing.Value;

                app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);

            }
            catch (System.Exception ex)
            {

            }
        }
        //private void SpellCheck()
        //{
        //    try
        //    {
        //        Word.Application app = new Word.Application();
        //        int errors = 0;
        //        if (txtCommentText.Text.Length > 0)
        //        {
        //            app.Visible = false;
                    
        //            // Setting these variables is comparable to passing null to the function.
        //            // This is necessary because the C# null cannot be passed by reference.
        //            object template = Missing.Value;
        //            object newTemplate = Missing.Value;
        //            object documentType = Missing.Value;
        //            object visible = true;

        //            Word._Document doc1 = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);

        //            doc1.Words.First.InsertBefore(txtCommentText.Text);
        //            Word.ProofreadingErrors spellErrorsColl = doc1.SpellingErrors;
        //            errors = spellErrorsColl.Count;

        //            object optional = Missing.Value;

        //            doc1.CheckSpelling(
        //                ref optional, ref optional, ref optional, ref optional, ref optional, ref optional,
        //                ref optional, ref optional, ref optional, ref optional, ref optional, ref optional);

        //            object first = 0;
        //            object last = doc1.Characters.Count - 1;
        //            txtCommentText.Text = doc1.Range(ref first, ref last).Text;
        //        }

        //        object saveChanges = false;
        //        object originalFormat = Missing.Value;
        //        object routeDocument = Missing.Value;

        //        app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);

        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //}
    }
}