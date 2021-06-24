using FootballersCatalog.Web.ViewModel;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace FootballersCatalog.Web.SignalR
{
    public class ChatHub : Hub
    {
        public async Task AddFootballer(FootballerNameViewModel footballerNameViewModel)
        {
            await Clients.All.SendAsync("AddFootballer", footballerNameViewModel);
        }

        public async Task EditFootballer(FootballerNameViewModel footballerNameViewModel)
        {
            await Clients.All.SendAsync("EditFootballer", footballerNameViewModel);
        }
    }
}
