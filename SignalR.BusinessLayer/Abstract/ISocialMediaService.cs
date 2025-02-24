using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface ISocialMediaService : IGenericService<SocialMedia>
    {
        void TChangeStatusToTrue(int id);
        void TChangeStatusToFalse(int id);
    }
}