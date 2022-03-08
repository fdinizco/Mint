using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using SlotGroups.Common;
using SlotGroups.Models.Response;
using SlotGroups.Services.Remote;
using Xamarin.Forms;

namespace SlotGroups.ViewModels
{
    public class SlotGroupsPageViewModel : BaseViewModel
    {
        #region Variables
        SlotGroupsInfo slotGroupsInfo;

        private ObservableCollection<string> _groupName;
        public ObservableCollection<string> GroupName
        {
            get => _groupName;
            set => _groupName = value;
        }

        private bool _searchActivated = false;
        public bool SearchActivated
        {
            get { return _searchActivated; }
            set { SetProperty(ref _searchActivated, value); }
        }
        #endregion

        #region Command
        public ICommand BackCommand => new AsyncCommand(NavigateAsync);
        public ICommand SearchComand => new Command(ActivateSearch);
        public ICommand CancelComand => new Command(CancelSearch);
        #endregion


        private async Task NavigateAsync() { await App.Current.MainPage.Navigation.PopAsync(); }
        private void ActivateSearch() { SearchActivated = true; }
        private void CancelSearch() { SearchActivated = false; }


        private void RetriveSlotGroupInformation()
        {
            Title = "Loading";
            IsBusy = true;
            if (IsInternetConnected)
            {
                Task.Run(async () =>
                {
                    await GetOnlineInformationAsync();
                });
            }
            else
            {
                Task.Run(async () =>
                {
                    await GetOfflineInformationAsync();
                });
            }
        }

        async Task GetOnlineInformationAsync()
        {
            var getInfoAsyc = await RESTServices.RetriveSlotGroupInfoFromServerAsync();
            string response = getInfoAsyc;
            slotGroupsInfo = new SlotGroupsInfo();
            try
            {
                slotGroupsInfo = SlotGroupsInfo.FromJson(response);
                UpdateScreen();
            }
            catch (Exception ex)
            {
                ErrorResponse errorResponse = new ErrorResponse
                {
                    Message = ex.ToString()
                };
            }
        }

        private void UpdateScreen()
        {
            IsBusy = false;
            Title = slotGroupsInfo.CategoryName;
            UpdateGroupNameList();
        }

        private void UpdateGroupNameList()
        {
            if (GroupName.Any())
            {
                GroupName.Clear();
            }
            foreach (SlotGroup elem in slotGroupsInfo.SlotGroups)
            {
                GroupName.Add(elem.SlotGroupName);
            }
        }

        async Task GetOfflineInformationAsync()
        {
        }

        public SlotGroupsPageViewModel(INavigationService navigationService)
                    : base(navigationService)
        {
            GroupName = new ObservableCollection<string>();

            RetriveSlotGroupInformation();
        }
    }
}