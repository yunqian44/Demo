using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApi.Models.ViewModel
{
    public class LoadingPlantReq
    {
        /// <summary>
        /// 装运单信息
        /// </summary>
        public LoadingModeReq LoadingMode { get; set; }

        /// <summary>
        /// 途径节点信息
        /// </summary>
        public List<LoadingCustomerModel> LoadingCustomerList { get; set; }
    }

    public class LoadingCustomerModel
    {
        public int Sn { get; set; }

        public int CustomerType { get; set; }

        public int CustomerId { get; set; }
    }


    /// <summary>
    /// 装运单
    /// </summary>
    public class LoadingModeReq
    {
        /// <summary>
        /// 下单类型
        /// </summary>
        public LoadingTypeEnum Type { get; set; }

        /// <summary>
        /// 车长
        /// </summary>
        public decimal VehicleLength { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public VehicleTypeEnum VehicleType { get; set; }

        /// <summary>
        /// 时效
        /// </summary>
        public decimal TimeLine { get; set; }

        /// <summary>
        /// 时效
        /// </summary>
        public DateTime DeliveryTime { get; set; }

        /// <summary>
        /// 始发地城市Id
        /// </summary>
        public int FromCityId { get; set; }

        /// <summary>
        /// 目的地城市Id
        /// </summary>
        public int ToCityId { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public decimal TotalWeight { get; set; }

        /// <summary>
        /// 体积
        /// </summary>
        public decimal TotalVolume { get; set; }

        /// <summary>
        /// 期望运费
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 承运商Id(货主企业Id)
        /// </summary>
        public int CorpId { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }

    public enum LoadingTypeEnum
    {
        /// <summary>
        /// 下单
        /// </summary>
        [Description("下单")]
        CorpPlant = 1,

        /// <summary>
        /// 代客下单
        /// </summary>
        [Description("代客下单")]
        CarrierPlant = 2
    }


    public enum VehicleTypeEnum
    {
        [Description("平板车")]
        Flat = 1,
        [Description("低栏车")]
        Hurdle = 2,
        [Description("高栏车")]
        HighSided = 3,
        [Description("半封闭车")]
        SemiClosed = 4,
        [Description("厢式车")]
        Van = 5,
        [Description("自卸车")]
        Dump = 6,
        [Description("冷藏车")]
        Refrigerated = 7,
        [Description("集装箱车")]
        Container = 8,
        [Description("轿车")]
        Sedan = 9,
        [Description("面包车")]
        Minivan = 10,
        [Description("未知车型")]
        Other = 999,
    }

}