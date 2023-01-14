using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01net_02_09_06
{
    public class Ticket
    {
        // 写一个ticket 类，有一个距离属性（本属性只读，在构造方法中赋值）
        //不能为负数，有一个价格属性，价格属性只读，
        //并且根据距离distance 计算价格price (1元、公里）
        // 0-100 不打折
        // 101-200公里 9.5折
        // 201-300 9折
        // 300以上 8折
        private double _distance;
        public double Distance
        {
            get { return _distance; }
            
        }

        public Ticket(double distance)
        {
            if (distance < 0) { distance = 0; }
            this._distance= distance;
        }

        private double _price;
        public double Price
        {
            get
            {

                if (_distance > 0 && _distance < 100)
                {
                    return _distance * 1.0;
                }
                else if (_distance >= 100 && _distance < 200)
                {
                    return _distance * 0.95;
                }
                else
                {
                    return _distance * 0.9;
                }
            }
        }

        public void showTicket()
        {
            Console.WriteLine("{0}mile need {1}",Distance,Price);
        }


    }
}
