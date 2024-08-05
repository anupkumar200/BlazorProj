using BlazorProj.Models;
using System.Data.SqlClient;

namespace BlazorProj.Clients
{
    public class CampaignClients
    {
        private readonly List<Campaign> campaigns =
        [
            new()
            {
                Id = 1,
                Name = "Test-1",
                StartDate = new DateOnly(2023, 12, 1),
                EndDate = new DateOnly(2023, 2, 10),
                Status = true,
                UpdatedOn = new DateTime(2023, 2, 2, 1, 5, 20)
            },
            new()
            {
                Id = 2,
                Name = "Test-2",
                StartDate = new DateOnly(2023, 12, 1),
                EndDate = new DateOnly(2023, 2, 10),
                Status = true,
                UpdatedOn = new DateTime(2023, 2, 2, 1, 5, 20)
            },
            new()
            {
                Id = 3,
                Name = "Test-3",
                StartDate = new DateOnly(2023, 12, 1),
                EndDate = new DateOnly(2023, 2, 10),
                Status = true,
                UpdatedOn = new DateTime(2023, 2, 2, 1, 5, 20)
            },
            new()
            {
                Id = 4,
                Name = "Test-4",
                StartDate = new DateOnly(2023, 12, 1),
                EndDate = new DateOnly(2023, 2, 10),
                Status = false,
                UpdatedOn = new DateTime(2023, 2, 2, 1, 5, 20)
            },
            new()
            {
                Id = 5,
                Name = "Test-5",
                StartDate = new DateOnly(2023, 12, 1),
                EndDate = new DateOnly(2023, 2, 10),
                Status = true,
                UpdatedOn = new DateTime(2023, 2, 2, 1, 5, 20)
            }
        ];

        public Campaign[] GetCampaigns() => [..campaigns];

        public void AddCampaign(CampaignDetails objCampaign)
        {
            var campaign = new Campaign
            {
                Id = campaigns.Count + 1,
                Name = objCampaign.Name,
                StartDate= objCampaign.StartDate,
                EndDate= objCampaign.EndDate,
                Status = objCampaign.Status,
                UpdatedOn = objCampaign.UpdatedOn
            };
            campaigns.Add(campaign);
        }

        public CampaignDetails GetCampaign(long id)
        {
            Campaign campaign = GetCampaignById(id);
            return new CampaignDetails
            {
                Id = campaign.Id,
                Name = campaign.Name,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate,
                Status = campaign.Status,
                UpdatedOn = campaign.UpdatedOn
            };
        }

        private Campaign GetCampaignById(long id)
        {
            Campaign? campaign = campaigns.Find(c => c.Id == id);
            ArgumentNullException.ThrowIfNull(campaign);
            return campaign;
        }

        public void UpdateCampaign(CampaignDetails updateCampaign)
        {
            Campaign existingCampaign = GetCampaignById(updateCampaign.Id);

            existingCampaign.Name = updateCampaign.Name;
            existingCampaign.StartDate = updateCampaign.StartDate;
            existingCampaign.EndDate = updateCampaign.EndDate;
            existingCampaign.Status = updateCampaign.Status;
            existingCampaign.UpdatedOn = updateCampaign.UpdatedOn;
        }

        public void DeleteCampaign(long id)
        {
            var campaign = GetCampaignById(id);
            campaigns.Remove(campaign);
        }

    }
}
