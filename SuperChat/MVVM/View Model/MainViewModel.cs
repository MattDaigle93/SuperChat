using SuperChat.Core;
using SuperChat.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SuperChat.MVVM.View_Model
{
    internal class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* Commands */

        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedcontact;

        public ContactModel SelectedContact
        {
            get { return _selectedcontact; }
            set 
            { 
                _selectedcontact = value; 
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            { 
                _message = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false,
                });

                Message = "";
            });

            Messages.Add(new MessageModel
            {
                Username = "Matt Daigle",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/2spsXAx.jpeg",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true,
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Matt Daigle",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/2spsXAx.jpeg",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false,
                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Super",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/mP4PK45.jpeg",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = true
                });
            }
            Messages.Add(new MessageModel
            {
                Username = "Super",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/mP4PK45.jpeg",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Matt Daigle {i}",
                    ImageSource = "https://i.imgur.com/2spsXAx.jpeg",
                    Messages = Messages
                });
            }
        }
    }
}
