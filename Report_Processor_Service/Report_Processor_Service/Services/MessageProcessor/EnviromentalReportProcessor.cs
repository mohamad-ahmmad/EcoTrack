using EcoTrack.PL.Entities;
using EcoTrack.PL.Repositories.Users.Interface;
using Report_Processor_Service.Models;

namespace Report_Processor_Service.Services.MessageProcessor
{
    public class EnviromentalReportProcessor : IMessageProcessor<EnviromentalReportMessage>
    {
        private readonly IUserRepository _userRepo;

        public EnviromentalReportProcessor(IUserRepository userRepo)
        {
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }
        public async Task Process(EnviromentalReportMessage message)
        {
            var userId = message.UserId;
            var user = await _userRepo.GetUserById((int)userId, false, true);
            if (user is null)
            {
                return;
            }

            var usersToNotify = new List<User>();
            foreach(var follower in user.Followers)
            {
                bool shouldNotify = follower.enviromentalThresholds
                    .Any(th => 
                            th.Value <= message.Value && 
                            th.EnviromentalReportsTopic.Name == message.Topic);

                if (shouldNotify)
                {
                    usersToNotify.Add(follower);
                }
            }

            // TODO: notify each user
        }

    }
}
