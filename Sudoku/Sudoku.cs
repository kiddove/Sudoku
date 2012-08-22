using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Sudoku
{
    class CurPos
    {
        private int row;
        private int col;

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }
        public int Col
        {
            get
            {
                return col;
            }
            set
            {
                col = value;
            }
        }
        // Construction
        public CurPos()
        {
            row = 0;
            col = 0;
        }
        //public bool MoveNext()
        //{
        //    col++;
        //    if (col > 9)
        //    {
        //        row++;
        //        col = 1;
        //    }
        //    if (row > 9)
        //        return false;
        //    else
        //        return true;
        //}
        //public bool MovePrevious()
        //{
        //    col--;
        //    if (col < 0)
        //    {
        //        col = 9;
        //        row--;
        //    }
        //    if (row < 1)
        //        return false;
        //    else
        //        return true;
        //}
        //public void MoveToBegin()
        //{
        //    row = 1;
        //    col = 1;
        //}
        //public void MoveToEnd()
        //{
        //    row = 9;
        //    col = 9;
        //}
    }
    // Sudoku 
    class Sudoku
    {
        private SudokuCell[][] m_SudokuArray;
        public const int m_iSize = 9;
        private CurPos m_CurPos = new CurPos();
        // construction
        public Sudoku()
        {
            try
            {
                m_SudokuArray = new SudokuCell[m_iSize][];
                for (int i = 0; i < m_iSize; i++)
                {
                    SudokuCell[] cells = new SudokuCell[m_iSize];
                    for (int j = 0; j < m_iSize; j++)
                    {
                        //cells[j] = new SudokuCell(i, j);
                        cells[j] = new SudokuCell();
                    }
                    m_SudokuArray[i] = cells;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }

        // Initialization
        public void Init()
        {
            try
            {
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }

        public void Clear()
        {
            try
            {
                m_CurPos.Row = 0;
                m_CurPos.Col = 0;
                for (int i = 0; i < m_iSize; i++)
                {
                    for (int j = 0; j < m_iSize; j++)
                    {
                        SetCellInit(i, j);
                    }
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }
        public void InitFromInput(string strInput)
        {
            try
            {
                // Get Input From the Form
                //string[] sArray = strInput.Split('\n');
                // string str = "\r\n";
                //Regex reg;
                string[] sArray = Regex.Split(strInput, "\r\n", RegexOptions.None);
                //string[] sArr = strInput.Split(new char[2]{'\r','\n'});
                int iRow = 0;
                Trace.Write("\r\n");
                foreach (string str in sArray)
                {
                    if (str.Length == 9)
                    {
                        char[] szNum = str.ToCharArray();
                        int iCol = 0;
                        foreach (char sz in szNum)
                        {
                            int iValue = sz - '0';
                            if (iValue > 0)
                            {
                                m_SudokuArray[iRow][iCol].Value = iValue;
                                m_SudokuArray[iRow][iCol].Visited = true;
                                m_SudokuArray[iRow][iCol].Inited = true;
                                Trace.Write(iValue.ToString());
                            }
                            else
                            {
                                m_SudokuArray[iRow][iCol].Value = 0;
                                m_SudokuArray[iRow][iCol].Visited = false;
                                Trace.Write(iValue.ToString());
                            }
                            iCol++;
                        }
                    }
                    iRow++;
                    Trace.Write("\r\n");
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }
        public SudokuCell GetCell(int iRow, int iCol)
        {
            try
            {
                return m_SudokuArray[iRow][iCol];
            }
            catch (ArgumentNullException ane)
            {
                Trace.WriteLine(ane.Message);
                return null;
            }
            catch (InvalidCastException ice)
            {
                Trace.WriteLine(ice.Message);
                return null;
            }
            catch (IndexOutOfRangeException iore)
            {
                Trace.WriteLine(iore.Message);
                return null;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return null;
            }
        }
        public void SetCellValue(int iRow, int iCol, int iValue)
        {
            try
            {
                m_SudokuArray[iRow][iCol].Value = iValue;
            }
            catch (ArgumentNullException ane)
            {
                Trace.WriteLine(ane.Message);
                //return null;
            }
            catch (InvalidCastException ice)
            {
                Trace.WriteLine(ice.Message);
                //return null;
            }
            catch (IndexOutOfRangeException iore)
            {
                Trace.WriteLine(iore.Message);
                //return null;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                //return null;
            }
        }
        public void SetCellVisit(int iRow, int iCol, bool bVisited)
        {
            try
            {
                m_SudokuArray[iRow][iCol].Visited = bVisited;
            }
            catch (ArgumentNullException ane)
            {
                Trace.WriteLine(ane.Message);
                //return null;
            }
            catch (InvalidCastException ice)
            {
                Trace.WriteLine(ice.Message);
                //return null;
            }
            catch (IndexOutOfRangeException iore)
            {
                Trace.WriteLine(iore.Message);
                //return null;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                //return null;
            }
        }
        public void SetCellInit(int iRow, int iCol)
        {
            try
            {
                m_SudokuArray[iRow][iCol].Init();
            }
            catch (ArgumentNullException ane)
            {
                Trace.WriteLine(ane.Message);
                //return null;
            }
            catch (InvalidCastException ice)
            {
                Trace.WriteLine(ice.Message);
                //return null;
            }
            catch (IndexOutOfRangeException iore)
            {
                Trace.WriteLine(iore.Message);
                //return null;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                //return null;
            }
        }
        public CurPos CurPos
        {
            get
            {
                return m_CurPos;
            }
        }
        public bool MoveNext()
        {
            try
            {
                m_CurPos.Col++;
                if (m_CurPos.Col > 8)
                {
                    m_CurPos.Row++;
                    m_CurPos.Col = 0;
                }
                if (m_CurPos.Row > 8)
                    return false;
//                if (!bInit && m_SudokuArray[m_CurPos.Row][m_CurPos.Col].Inited)
                if (m_SudokuArray[m_CurPos.Row][m_CurPos.Col].Inited)
                    return MoveNext();
                else
                    return true;
            }
            catch (ArgumentNullException ane)
            {
                Trace.WriteLine(ane.Message);
                return false;
            }
            catch (InvalidCastException ice)
            {
                Trace.WriteLine(ice.Message);
                return false;
            }
            catch (IndexOutOfRangeException iore)
            {
                Trace.WriteLine(iore.Message);
                return false;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
        }
        public bool MoveNextInput()
        {
            try
            {
                m_CurPos.Col++;
                if (m_CurPos.Col > 8)
                {
                    m_CurPos.Row++;
                    m_CurPos.Col = 0;
                }
                if (m_CurPos.Row > 8)
                    return false;
                //                if (!bInit && m_SudokuArray[m_CurPos.Row][m_CurPos.Col].Inited)
                //if (m_SudokuArray[m_CurPos.Row][m_CurPos.Col].Inited)
                //    return MoveNext();
                else
                    return true;
            }
            catch (ArgumentNullException ane)
            {
                Trace.WriteLine(ane.Message);
                return false;
            }
            catch (InvalidCastException ice)
            {
                Trace.WriteLine(ice.Message);
                return false;
            }
            catch (IndexOutOfRangeException iore)
            {
                Trace.WriteLine(iore.Message);
                return false;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
        }
        public bool MovePrevious()
        {
            try
            {
                m_CurPos.Col--;
                if (m_CurPos.Col < 0)
                {
                    m_CurPos.Col = 8;
                    m_CurPos.Row--;
                }
                if (m_CurPos.Row < 0)
                    return false;
                if (m_SudokuArray[m_CurPos.Row][m_CurPos.Col].Inited)
                    return MovePrevious();
                else
                    return true;
            }
            catch (ArgumentNullException ane)
            {
                Trace.WriteLine(ane.Message);
                return false;
            }
            catch (InvalidCastException ice)
            {
                Trace.WriteLine(ice.Message);
                return false;
            }
            catch (IndexOutOfRangeException iore)
            {
                Trace.WriteLine(iore.Message);
                return false;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
        }
        public void MoveToBegin()
        {
            m_CurPos.Row = 0;
            m_CurPos.Col = 0;
        }
        public void MoveToEnd()
        {
            m_CurPos.Row = 8;
            m_CurPos.Col = 8;
        }
        public bool IsValidValue(int iRow, int iCol, int iValue)
        {
            // Row
            for (int i = 0; i < 9; i++)
            {
                SudokuCell sdkCell = GetCell(iRow, i);
                if (sdkCell.Visited == true && sdkCell.Value == iValue)
                    return false;
            }
            // Col
            for (int i = 0; i < 9; i++)
            {
                SudokuCell sdkCell = GetCell(i, iCol);
                if (sdkCell.Visited == true && sdkCell.Value == iValue)
                    return false;
            }
            // 9
            int iRowStart = (iRow / 3) * 3;
            int iColStart = (iCol / 3) * 3;
            for (int i = iRowStart; i < iRowStart + 3; i++)
            {
                for (int j = iColStart; j < iColStart + 3; j++)
                {
                    if (i != iRow && i != iCol)
                    {
                        SudokuCell sdkCell = GetCell(i, j);
                        if (sdkCell.Visited == true && sdkCell.Value == iValue)
                            return false;
                    }
                }
            }
            return true;
        }
        public void RemoveFromList(int iRow, int iCol, int iValue)
        {
            try
            {
                m_SudokuArray[iRow][iCol].RemoveFromList(iValue);
            }
            catch (ArgumentNullException ane)
            {
                Trace.WriteLine(ane.Message);
                //return null;
            }
            catch (InvalidCastException ice)
            {
                Trace.WriteLine(ice.Message);
                //return null;
            }
            catch (IndexOutOfRangeException iore)
            {
                Trace.WriteLine(iore.Message);
                //return null;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                //return null;
            }
        }
        public void Print()
        {
            for (int i = 0; i < 9; i++)
            {
                Trace.Write("\r\n");
                for (int j = 0; j < 9; j++)
                {
                    SudokuCell sdkCell = GetCell(i, j);
                    Trace.Write(sdkCell.Value.ToString());
                }
            }
            Trace.WriteLine("\r\n");
        }

        public void Answer()
        {
            // choose a number
            // if it is invalid,removed from the list
            // if all are invalid,come to previous,and reset the list
            MoveToBegin();
            while (true)
            {
                bool bNext = true;
                SudokuCell sdkCell = GetCell(m_CurPos.Row, m_CurPos.Col);
                if (!sdkCell.Visited)
                {
                    int iValue = sdkCell.GetAvailableValue();
                    while (iValue > 0)
                    {
                        // If all is invalid,back to the previous,and clean this one
                        // 
                        if (IsValidValue(m_CurPos.Row, m_CurPos.Col, iValue))
                        {
                            //sdkCell.Value = iValue;
                            SetCellValue(m_CurPos.Row, m_CurPos.Col, iValue);
                            //sdkCell.Visited = true;
                            SetCellVisit(m_CurPos.Row, m_CurPos.Col, true);
                            RemoveFromList(m_CurPos.Row, m_CurPos.Col, iValue);
                            bNext = true;
                            break;
                        }
                        else
                            RemoveFromList(m_CurPos.Row, m_CurPos.Col, iValue);
                        iValue = sdkCell.GetAvailableValue();
                    }

                    if (iValue <= 0)
                        bNext = false;

                    if (bNext)
                    {
                        if (!MoveNext())
                        {
                            Print();
                            break;
                        }
                    }

                    else
                    {
                        SetCellInit(m_CurPos.Row, m_CurPos.Col);
                        MovePrevious();
                        //SudokuCell sdkCellPre = GetCell(m_CurPos.Row, m_CurPos.Col);
                        //sdkCellPre.Visited = false;
                        //SetCellInit(m_CurPos.Row, m_CurPos.Col);
                        //RemoveFromList(m_CurPos.Row, m_CurPos.Col, iVal);
                        SetCellValue(m_CurPos.Row, m_CurPos.Col, 0);
                        SetCellVisit(m_CurPos.Row, m_CurPos.Col, false);
                    }
                }
                else
                    MoveNext();
//                Print();
            }
            //Print();
        }
    }

    class SudokuCell
    {
        private int m_iValue;
        private bool m_bVisited;
        private bool m_bInit;
        private List<Int32> m_Available = new List<Int32>();
        // construction
        public SudokuCell()
        {
            //try
            //{
            //    m_iValue = 0;
            //    m_bVisited = false;
            //    m_bInit = false;
            //    for (int i = 1; i < 10; i++)
            //    {
            //        m_Available.Add(i);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Trace.WriteLine(e.Message);
            //}
            Init();
        }
        public void Init()
        {
            try
            {
                m_iValue = 0;
                m_bVisited = false;
                m_bInit = false;
                for (int i = 1; i < 10; i++)
                {
                    m_Available.Add(i);
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }
        //public SudokuCell(int iRow,int iCol)
        //{
        //    m_iValue = iRow * 10 + iCol;
        //    m_bVisited = false;
        //}
        // Attribute
        public int Value
        {
            get
            {
                return m_iValue;
            }
            set
            {
                m_iValue = value;
            }
        }

        public bool Visited
        {
            get
            {
                return m_bVisited;
            }
            set
            {
                m_bVisited = value;
            }
        }

        public bool Inited
        {
            get
            {
                return m_bInit;
            }
            set
            {
                m_bInit = value;
            }
        }
        // befor
        public int GetAvailableValue()
        {
            try
            {
                if (m_Available.Count > 0)
                    return m_Available[0];
                else
                    return 0;
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Trace.WriteLine(aore.Message);
                return 0;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return 0;
            }
        }

        // after set value
        public void RemoveFromList(int iValue)
        {
            try
            {
                m_Available.Remove(iValue);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }
    }
}
