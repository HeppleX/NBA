using System;

namespace NBA
{
    class NBAviewmodel
    {
        public NBAmodel nbamodel { get; set; }
        public DelegateCommand OperateCommand { get; set; }
        public DelegateCommand OperateCommand1 { get; set; }
        public DelegateCommand OperateCommand2 { get; set; }
        public DelegateCommand OperateCommand3 { get; set; }
        public DelegateCommand OperateCommand4 { get; set; }
        public DelegateCommand OperateCommand5 { get; set; }
        public DelegateCommand OperateCommand6 { get; set; }

        public NBAviewmodel()
        {
            nbamodel = new NBAmodel();
            OperateCommand = new DelegateCommand();
            OperateCommand.ExecuteCommand = new Action<object>(Operate);
            OperateCommand1 = new DelegateCommand();
            OperateCommand1.ExecuteCommand = new Action<object>(Operate1);
            OperateCommand2 = new DelegateCommand();
            OperateCommand2.ExecuteCommand = new Action<object>(Operate2);
            OperateCommand3 = new DelegateCommand();
            OperateCommand3.ExecuteCommand = new Action<object>(Operate3);
            OperateCommand4 = new DelegateCommand();
            OperateCommand4.ExecuteCommand = new Action<object>(Operate4);
            OperateCommand5 = new DelegateCommand();
            OperateCommand5.ExecuteCommand = new Action<object>(Operate5);
            OperateCommand6 = new DelegateCommand();
            OperateCommand6.ExecuteCommand = new Action<object>(Operate6);
        }
        public void Operate(object obj)
        {
            nbamodel.SetPosition(0);
        }

        public void Operate1(object obj)
        {
            int pos = nbamodel.GetPosition();
            nbamodel.SetPosition(pos - 1);
        }

        public void Operate2(object obj)
        {
            int pos = nbamodel.GetPosition();
            nbamodel.SetPosition(pos + 1);
        }

        public void Operate3(object obj)
        {
            int pos = nbamodel.NBADataSet.Tables["Team"].Rows.Count - 1;
            nbamodel.SetPosition(pos);
        }

        public void Operate4(object obj)
        {
            Record record = new Record();           
            record.Show();
        }

       
        public void Operate5(object obj)
        {
            statistic statistic = new statistic();
            statistic.Show();
        }

        public void Operate6(object obj)
        {
            match match = new match();
            match.Show();
        }
      
    }
}
