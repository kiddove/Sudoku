using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sudoku
{
    public partial class SudokuForm : Form
    {
        public SudokuForm()
        {
            InitializeComponent();
            sdk = new Sudoku();
            this.dataGridViewSudoku.Rows.Add(9);
            this.dataGridViewAnswer.Rows.Add(9);
            this.dataGridViewAnswer.Visible = false;
            //this.textBoxResult.Visible = false;
        }
        static int m_iSize = 9;
        private Sudoku sdk;
        private void InitGridSudoku()
        {
            this.dataGridViewSudoku.Rows.Clear();
            this.dataGridViewSudoku.Rows.Add(9);
        }
        private void InitGridAnswer()
        {
            this.dataGridViewAnswer.Rows.Clear();
            this.dataGridViewAnswer.Rows.Add(9);
        }

        private void Random()
        {
            try
            {
                sdk.Clear();
                sdk.Answer();
                this.dataGridViewAnswer.Visible = true;
                for (int i = 0; i < m_iSize; i++)
                    for (int j = 0; j < m_iSize; j++)
                    {
                        SudokuCell sdkCell = sdk.GetCell(i, j);
                        this.dataGridViewAnswer[j, i].Value = sdkCell.Value;
                        this.dataGridViewAnswer[j, i].ReadOnly = true;
                    }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            //Random();
            //return;
            InitGridSudoku();
            try
            {
                sdk.Clear();
                sdk.InitFromInput(this.textBoxResult.Text);
                // Init the View
                do
                {
                    SudokuCell sdkCell = sdk.GetCell(sdk.CurPos.Row, sdk.CurPos.Col);
                    if (sdkCell.Inited)
                    {
                        //this.dataGridViewSudoku[sdk.CurPos.Row, sdk.CurPos.Col].Value = sdkCell.Value;
                        //this.dataGridViewSudoku[sdk.CurPos.Row, sdk.CurPos.Col].ReadOnly = true;
                        this.dataGridViewSudoku[sdk.CurPos.Col, sdk.CurPos.Row].Value = sdkCell.Value;
                        this.dataGridViewSudoku[sdk.CurPos.Col, sdk.CurPos.Row].ReadOnly = true;

                    }
                }
                while (sdk.MoveNextInput());
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Trace.WriteLine(aore.Message);
                return;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return;
            }
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            InitGridAnswer();
            sdk.Answer();
            this.dataGridViewAnswer.Visible = true;
            for (int i = 0; i < m_iSize; i++)
                for (int j = 0; j < m_iSize; j++)
                {
                    SudokuCell sdkCell = sdk.GetCell(i, j);
                    this.dataGridViewAnswer[j, i].Value = sdkCell.Value;
                    this.dataGridViewAnswer[j, i].ReadOnly = true;
                }
        }
    }
}
