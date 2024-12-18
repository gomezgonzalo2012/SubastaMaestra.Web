﻿using SubastaMaestra.Models.DTOs.Bid;
using SubastaMaestra.WebSite.wwwroot.Modals;

namespace SubastaMaestra.WebSite.Services
{
    public interface IBidService
    {
        Task<bool> CreateBid(BidCreateDTO bid);
    }
}
