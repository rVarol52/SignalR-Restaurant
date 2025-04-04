﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;


namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfSliderDal: GenericRepository<Slider>, ISliderDal
    {
        public EfSliderDal(SignalRContext context) : base(context)
        {

        }
    }
}
