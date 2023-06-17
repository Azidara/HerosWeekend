using UnityEngine;

namespace AzMath {
    public class PolarVec2
    {
        public float r;
        private float _θ;
        public float θ {
            get {return _θ;}
            set {float tmp = value; 
                while(tmp < 0){tmp += 360;}
                _θ = tmp % 360;}
            }

        public static PolarVec2 zero {get {return new PolarVec2(0,0);}}
        public static PolarVec2 up {get {return new PolarVec2(1, 90);}}
        public static PolarVec2 right {get {return new PolarVec2(1,0);}}
        public static PolarVec2 down {get {return new PolarVec2(1,270);}}
        public static PolarVec2 left {get {return new PolarVec2(1,180);}}

        public PolarVec2(){
            this.r = 0;
            this.θ = 0;
        }

        public PolarVec2(float r, float θ){
            this.r = r;
            this.θ = θ;
        }

        public static PolarVec2 CartesianToPolar(Vector2 cartesian){
            return CartesianToPolar(cartesian.x, cartesian.y);
        }

        public static PolarVec2 CartesianToPolar(float x, float y){
            // r = Sqrt(x^2 + y^2)
            float r = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
            // θ = ArcTan2(y,x)
            float θ = Mathf.Atan2(y,x) * Mathf.Rad2Deg;

            return new PolarVec2(r, θ);
        }

        public static Vector2 PolartoCartesian(PolarVec2 polar){
            return PolartoCartesian(polar.r, polar.θ);
        }

        public static Vector2 PolartoCartesian(float r, float θ){
            // x = r * Cos(θ)
            float x = r * Mathf.Cos(θ * Mathf.Deg2Rad);
            // y = r * Sin(θ)
            float y = r * Mathf.Sin(θ * Mathf.Deg2Rad);

            return new Vector2(x,y);
        }

        // These all work but they aren't great implentations
        
        public static PolarVec2 operator +(PolarVec2 v1, PolarVec2 v2){
            return PolarVec2.CartesianToPolar(PolarVec2.PolartoCartesian(v1) + PolarVec2.PolartoCartesian(v2));
        }
        
        public static PolarVec2 operator -(PolarVec2 v){
            v.r = -v.r;
            return v;
        }
        public static PolarVec2 operator -(PolarVec2 v1, PolarVec2 v2){
            return v1 + -v2;
        }
        
        /*
        public static PolarVec2 operator +(PolarVec2 v1, PolarVec2 v2){
            PolarVec2 result = new PolarVec2();
            // r = Sqrt(r1^2 + r2^2 + 2*r1*r2*cos(θ1 + 180 - θ2))
            result.r = Mathf.Sqrt(Mathf.Pow(v1.r, 2) + Mathf.Pow(v2.r,2) + (2*v1.r*v2.r*Mathf.Cos(v2.θ - v1.θ)));
            // θ = θ1 + arctan2(r2*sin(θ2 - θ1), r1 + r2*cos(θ2 - θ1))
            result.θ = v1.θ + Mathf.Atan2(v2.r * Mathf.Sin(v2.θ - v1.θ), v1.r + v2.r*Mathf.Cos(v2.θ - v1.θ));
            return result;
        }
        */

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            var v2 = (PolarVec2)obj;
            return (this.r == v2.r && this.θ == v2.θ);
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.r.GetHashCode() ^ this.θ.GetHashCode();
        }

        public static bool operator ==(PolarVec2 v1, PolarVec2 v2){
            return v1.r == v2.r && v1._θ == v2._θ;
        }
        public static bool operator !=(PolarVec2 v1, PolarVec2 v2){
            return v1.r != v2.r || v1._θ != v2._θ;
        }

        override public string ToString(){
            return $"({r.ToString("F2")},{θ.ToString("F2")})";
        }
    }
}
