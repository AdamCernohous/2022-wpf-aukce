using Aukce.Data;
using Aukce.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
        public RelayCommand AddAuction { get; set; }
        public RelayCommand BidCommand { get; set; }

        private ObservableCollection<Auction> _auctions;
        private Auction _selectedAuction;
        private User _registerUser;
        private User _loginUser;
        private User _loggedUser;
        private Auction _newAuction;
        private int _bid;

        public MainViewModel()
        {
            RegisterUser = new User();
            LoginUser = new User();
            NewAuction = new Auction();

            ReloadCommand = new RelayCommand(
                () =>
                {
                    if (Db != null && LoggedUser != null)
                    {
                        Auctions = new ObservableCollection<Auction>(Db.Auctions.AsNoTracking().ToList());

                        foreach (var a in Auctions)
                        {
                            var author = Db.Users.Where(u => u.Id == a.AuthorId).FirstOrDefault();
                            a.Author = author;
                        }
                    }
                    else if (Db != null)
                    {
                        Auctions = new ObservableCollection<Auction>(Db.Auctions.AsNoTracking().ToList());

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
                    if(Db != null)
                    {
                        Db.Users.Add(new User { Username = RegisterUser.Username, Email = RegisterUser.Email, Password = RegisterUser.Password });
                        Db.SaveChanges();
                    }
                }
                );
            LoginCommand = new RelayCommand(
                () =>
                {
                    if(Db != null)
                    {
                        LoggedUser = Db.Users.Where(u => u.Email == LoginUser.Email).FirstOrDefault();

                        if(LoggedUser != null)
                        {
                            if(LoggedUser.Password == LoginUser.Password)
                            {


                                //LoggedUser = new User 
                                //{
                                //    Id = loginUser.Id,
                                //    Username = loginUser.Username,
                                //    Email = loginUser.Email,
                                //    Password = loginUser.Password
                                //};

                                //AuctionWindow auctionWindow = new AuctionWindow(Db);
                                //auctionWindow.Tag = "auctionWindow";
                                //auctionWindow.Show();

                                //foreach (Window window in Application.Current.Windows)
                                //{
                                //    if (window.Tag != null)
                                //    {
                                //        if (window.Tag.ToString() != "auctionWindow")
                                //        {
                                //            window.Close();
                                //        }
                                //    }
                                //    else
                                //    {
                                //        window.Close();
                                //    }
                                //}
                            }
                            else
                            {
                                MessageBox.Show("Nesprávný email nebo heslo!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Uživatel neexistuje!");
                        }
                    }
                }
                );
            AddAuction = new RelayCommand(
                () =>
                {
                    if (Db != null && LoggedUser != null)
                    {
                        Db.Auctions.Add(new Auction
                        {
                            Title = NewAuction.Title,
                            Description = NewAuction.Description,
                            Price = NewAuction.Price,
                            EndDate = NewAuction.EndDate,
                            AuthorId = LoggedUser.Id,
                            Author = LoggedUser,
                            LastBuyerId = LoggedUser.Id
                        });
                        Db.SaveChanges();
                    }
                }
                );
            BidCommand = new RelayCommand(
                () =>
                {
                    if (Db != null)
                    {
                        Auction a = Db.Auctions.Where(a => a.Id == SelectedAuction.Id).FirstOrDefault();

                        a.Price += Bid;
                        a.LastBuyerId = LoggedUser.Id;

                        Db.SaveChanges();
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
        public User LoggedUser
        {
            get { return _loggedUser; }
            set { _loggedUser = value; NotifyPropertyChanged(); }
        }
        public Auction NewAuction
        {
            get { return _newAuction; }
            set { _newAuction = value; NotifyPropertyChanged(); }
        }
        public int Bid
        {
            get { return _bid; }
            set { _bid = value; NotifyPropertyChanged(); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
