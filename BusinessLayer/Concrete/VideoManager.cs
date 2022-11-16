using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class VideoManager : IVideoService
    {
        IVideoDal _videoDal;

        public VideoManager(IVideoDal videoDal)
        {
            _videoDal = videoDal;
        }

        public List<Video> GetList()
        {
            return _videoDal.GetListAll();
        }

        public void TAdd(Video t)
        {
            _videoDal.Insert(t);
        }

        public void TDelete(Video t)
        {
            _videoDal.Delete(t);
        }

        public Video TGetByID(int id)
        {
            return _videoDal.GetByID(id);
        }

        public void TUpdate(Video t)
        {
            _videoDal.Update(t);
        }
    }
}
