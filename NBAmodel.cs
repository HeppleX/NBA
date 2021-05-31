using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;

namespace NBA
{
    class NBAmodel : INotifyPropertyChanged
    {
        private string tid, tname, did, stadium, championship,coach,cid;
        public string win, lose, percentage, lead;
        public string pname, score, rebound, assist,steal,block,sp,tsp,fsp;
        public string hscore, ascore,htid,atid;
        public DataSet NBADataSet;
        private OleDbConnection oleDbConnection;
        private OleDbDataAdapter oleDbDataAdapter;
        private int position = 22;
        public event PropertyChangedEventHandler PropertyChanged;

        public NBAmodel()
        {
            try
            {
                connectDb();
                loadTeam();
                loadDivision();
                loadPlayer();
                loadConference();
                loadRecord();
                loadStatistic();
                loadMatch();
                setModelPropertyFromTable(position);
                getPlayer();
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        private void connectDb()
        {
            oleDbConnection = new OleDbConnection("Provider=SQLOLEDB.1;Integrated Security=SSPI;" +
                "Persist Security Info=False;Initial Catalog=NBA");
            oleDbConnection.Open();
        }

        private void loadTeam()
        {
            oleDbDataAdapter = new OleDbDataAdapter("select * from Team", oleDbConnection);
            NBADataSet = new DataSet();
            oleDbDataAdapter.Fill(NBADataSet, "Team");
        }

        private void loadDivision()
        {
            oleDbDataAdapter.SelectCommand = new OleDbCommand("select * from Division", oleDbConnection);
            oleDbDataAdapter.Fill(NBADataSet, "Division");
        }

        private void loadPlayer()
        {
            oleDbDataAdapter.SelectCommand = new OleDbCommand("Select * From Player a", oleDbConnection);
            oleDbDataAdapter.Fill(NBADataSet, "Player");
        }

        private void loadConference()
        {
            oleDbDataAdapter.SelectCommand = new OleDbCommand("select * from Conference", oleDbConnection);
            oleDbDataAdapter.Fill(NBADataSet, "Conference");
        }

        private void loadRecord()
        {
            oleDbDataAdapter.SelectCommand = new OleDbCommand("select * from Record", oleDbConnection);
            oleDbDataAdapter.Fill(NBADataSet, "Record");
        }

        private void loadStatistic()
        {
            oleDbDataAdapter.SelectCommand = new OleDbCommand("select * from Statistic", oleDbConnection);
            oleDbDataAdapter.Fill(NBADataSet, "Statistic");
        }

        private void loadMatch()
        {
            oleDbDataAdapter.SelectCommand = new OleDbCommand("select * from Match", oleDbConnection);
            oleDbDataAdapter.Fill(NBADataSet, "Match");
        }

        public void setModelPropertyFromTable(int position)
        {
            Tid = NBADataSet.Tables["Team"].Rows[position]["tid"].ToString();
            Tname = NBADataSet.Tables["Team"].Rows[position]["tname"].ToString();
            Did = NBADataSet.Tables["Team"].Rows[position]["did"].ToString();
            Stadium = NBADataSet.Tables["Team"].Rows[position]["stadium"].ToString();
            Championship = NBADataSet.Tables["Team"].Rows[position]["championship"].ToString();
            Coach = NBADataSet.Tables["Team"].Rows[position]["coach"].ToString();
            Cid = NBADataSet.Tables["Team"].Rows[position]["cid"].ToString();
            Win= NBADataSet.Tables["Record"].Rows[position]["win"].ToString();
            Lose = NBADataSet.Tables["Record"].Rows[position]["lose"].ToString();
            Percentage = NBADataSet.Tables["Record"].Rows[position]["percentage"].ToString();
            Lead = NBADataSet.Tables["Record"].Rows[position]["lead"].ToString();
            Pname = NBADataSet.Tables["Player"].Rows[position]["pname"].ToString();
            Score = NBADataSet.Tables["Statistic"].Rows[position]["score"].ToString();
            Rebound = NBADataSet.Tables["Statistic"].Rows[position]["rebound"].ToString();
            Assist = NBADataSet.Tables["Statistic"].Rows[position]["assist"].ToString(); 
            Steal = NBADataSet.Tables["Statistic"].Rows[position]["steal"].ToString(); 
            Block = NBADataSet.Tables["Statistic"].Rows[position]["block"].ToString();
            SP  = NBADataSet.Tables["Statistic"].Rows[position]["sp"].ToString(); 
            TSP = NBADataSet.Tables["Statistic"].Rows[position]["3sp"].ToString(); 
            FSP = NBADataSet.Tables["Statistic"].Rows[position]["fsp"].ToString();
            Hscore = NBADataSet.Tables["Match"].Rows[position]["hscore"].ToString();
            Ascore = NBADataSet.Tables["Match"].Rows[position]["ascore"].ToString();
            HTid = NBADataSet.Tables["Match"].Rows[position]["htid"].ToString();
            ATid = NBADataSet.Tables["Match"].Rows[position]["atid"].ToString();
        }

        private void getPlayer()
        {
            NBADataSet.Tables["Player"].DefaultView.RowFilter = "tid='" + Tid + "'";
        }

        public void SetPosition(int value)
        {
            position = value;
            if (position < 0)
                position = 0;
            if (position >= NBADataSet.Tables["Team"].Rows.Count)
                position = NBADataSet.Tables["Team"].Rows.Count - 1;
            setModelPropertyFromTable(position);
            getPlayer();
        }

        public int GetPosition()
        {

            return position;
        }

        public DataSet DataSet
        {
            get
            {
                return NBADataSet;
            }
            set
            {

            }
        }

        public string Tid
        {
            get
            {
                return tid;
            }
            set
            {
                tid = value;
                NBADataSet.Tables["Team"].Rows[position]["tid"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Tid"));
            }
        }

        public string Tname
        {
            get
            {
                return tname;
            }
            set
            {
                tname = value;
                NBADataSet.Tables["Team"].Rows[position]["tname"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Tname"));
            }
        }

        public string Did
        {
            get
            {
                return did;
            }
            set
            {
                did = value;
                NBADataSet.Tables["Team"].Rows[position]["did"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Did"));
            }
        }

        public string Cid
        {
            get
            {
                return cid;
            }
            set
            {
                cid = value;
                NBADataSet.Tables["Team"].Rows[position]["cid"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Cid"));
            }
        }

        public string Stadium
        {
            get
            {
                return stadium;
            }
            set
            {
                stadium = value;
                NBADataSet.Tables["Team"].Rows[position]["stadium"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Stadium"));
            }
        }

        public string Championship
        {
            get
            {
                return championship;
            }
            set
            {
                championship = value;
                NBADataSet.Tables["Team"].Rows[position]["championship"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Championship"));
            }
        }
        public string Coach
        {
            get
            {
                return coach;
            }
            set
            {
                coach = value;
                NBADataSet.Tables["Team"].Rows[position]["coach"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Coach"));
            }
        }
        public string Win
        {
            get
            {
                return win;
            }
            set
            {
                win = value;
                NBADataSet.Tables["Record"].Rows[position]["win"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Win"));
            }
        }
        public string Lose
        {
            get
            {
                return lose;
            }
            set
            {
                lose = value;
                NBADataSet.Tables["Record"].Rows[position]["lose"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Lose"));
            }
        }
        public string Percentage
        {
            get
            {
                return percentage;
            }
            set
            {
                percentage = value;
                NBADataSet.Tables["Record"].Rows[position]["percentage"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Percentage"));
            }
        }
        public string Lead
        {
            get
            {
                return lead;
            }
            set
            {
                lead = value;
                NBADataSet.Tables["Record"].Rows[position]["lead"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Lead"));
            }
        }

        public string Pname
        {
            get
            {
                return pname;
            }
            set
            {
                pname = value;
                NBADataSet.Tables["Player"].Rows[position]["pname"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Pname"));
            }
        }

        public string Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                NBADataSet.Tables["Statistic"].Rows[position]["score"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Score"));
            }
        }

        public string Rebound
        {
            get
            {
                return rebound;
            }
            set
            {
                rebound = value;
                NBADataSet.Tables["Statistic"].Rows[position]["rebound"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Rebound"));
            }
        }

        public string Assist
        {
            get
            {
                return assist;
            }
            set
            {
                assist = value;
                NBADataSet.Tables["Statistic"].Rows[position]["assist"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Assist"));
            }
        }

        public string Steal
        {
            get
            {
                return steal;
            }
            set
            {
                steal = value;
                NBADataSet.Tables["Statistic"].Rows[position]["steal"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Steal"));
            }
        }

        public string SP
        {
            get
            {
                return sp;
            }
            set
            {
                sp = value;
                NBADataSet.Tables["Statistic"].Rows[position]["sp"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SP"));
            }
        }

        public string Block
        {
            get
            {
                return block;
            }
            set
            {
                block = value;
                NBADataSet.Tables["Statistic"].Rows[position]["block"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Block"));
            }
        }

        public string TSP
        {
            get
            {
                return tsp;
            }
            set
            {
                tsp = value;
                NBADataSet.Tables["Statistic"].Rows[position]["3sp"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("TSP"));
            }
        }

        public string FSP
        {
            get
            {
                return fsp;
            }
            set
            {
                fsp = value;
                NBADataSet.Tables["Statistic"].Rows[position]["fsp"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FSP"));
            }
        }

        public string Hscore
        {
            get
            {
                return hscore;
            }
            set
            {
                hscore = value;
                NBADataSet.Tables["Match"].Rows[position]["hscore"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Hscore"));
            }
        }

        public string Ascore
        {
            get
            {
                return ascore;
            }
            set
            {
                ascore = value;
                NBADataSet.Tables["Match"].Rows[position]["ascore"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Ascore"));
            }
        }

        public string HTid
        {
            get
            {
                return htid;
            }
            set
            {
                htid = value;
                NBADataSet.Tables["Match"].Rows[position]["htid"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("HTid"));
            }
        }

        public string ATid
        {
            get
            {
                return atid;
            }
            set
            {
                atid = value;
                NBADataSet.Tables["Match"].Rows[position]["atid"] = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ATid"));
            }
        }
    }
}
