using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpWinNl.Behaviors;

namespace SampleMessagePopup
{
  public class MainViewModel : ViewModelBase
  {
    public ICommand MessageCommand
    {
      get
      {
        return new RelayCommand(
          () => 
            Messenger.Default.Send(new MessageDialogMessage(
              "Do you really want to do this?", "My Title", 
              "Hell yeah!", "No way", 
              HellYeah, Nope)));
      }
    }

    private async Task HellYeah()
    {
      Result = "Hell yeah!";
    }

    private async Task Nope()
    {
      Result = "NOOOO!";
    }


    private string result = "what?";
    public string Result
    {
      get { return result; }
      set { Set(() => Result, ref result, value); }
    }
  }
}
