﻿using Aukce.Data;
using Aukce.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aukce.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ApplicationDbContext Db { get; set; }
        public RelayCommand ReloadCommand { get; set; }

        private ObservableCollection<Auction> _auctions;
        private Auction _selectedAuction;

        public MainViewModel()
        {
            ReloadCommand = new RelayCommand(
                () =>
                {
                    if(Db != null)
                    {
                        Auctions = new ObservableCollection<Auction>(Db.Auctions.ToList());

                        foreach (var a in Auctions)
                        {
                            var author = Db.Users.Where(u => u.Id == a.AuthorId).FirstOrDefault();
                            a.Author = author;
                        }
                    }
                }
                );
        }
        public ObservableCollection<Auction> Auctions
        {
            get { return _auctions; }
            set { _auctions = value; NotifyPropertyChanged(); }
        }

        public Auction SelectedAuction
        {
            get { return _selectedAuction; }
            set { _selectedAuction = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
