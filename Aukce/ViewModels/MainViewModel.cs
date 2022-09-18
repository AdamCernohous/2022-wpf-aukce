﻿using Aukce.Data;
using Aukce.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aukce.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ApplicationDbContext Db { get; set; }
        public RelayCommand ReloadCommand { get; set; }
        public RelayCommand RegisterCommand { get; set; }
        public RelayCommand LoginCommand { get; set; }

        private ObservableCollection<Auction> _auctions;
        private Auction _selectedAuction;
        private User _registerUser;
        private User _loginUser;

        public MainViewModel()
        {
            RegisterUser = new User();

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
            RegisterCommand = new RelayCommand(
                () =>
                {
                    var newUser = new User
                    {
                        //Id = new Guid("00000000-0000-0000-0000-000000000000"),
                        Username = RegisterUser.Username,
                        Email = RegisterUser.Email,
                        Password = RegisterUser.Password
                    };

                    Trace.WriteLine(newUser);

                    Db.Users.Add(newUser);
                    Db.SaveChangesAsync();
                }
                );
            LoginCommand = new RelayCommand(
                () =>
                {
                    if(Db != null)
                    {

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
        public User RegisterUser
        {
            get { return _registerUser; }
            set { _registerUser = value; NotifyPropertyChanged(); }
        }
        public User LoginUser
        {
            get { return _loginUser; }
            set { _loginUser = value; NotifyPropertyChanged(); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
