class Program
{
    static void Main(string[] args)
    {
        CalculatorKCal user = new CalculatorKCal(1,183,80,18,true,2);
        Console.WriteLine(user.calculate());
    }
}

class CalculatorKCal{
    private int statureType;
    private int height;
    private int weight;
    private int age;
    private bool sex;
    private int activity;

    private ActivityImplementor activityModifier;
    private SexImplementor sexModifier;

    public CalculatorKCal(int statureType, int height, int weight, int age, bool sex, int activity){
        this.statureType=statureType;
        this.height=height;
        this.weight=weight;
        this.age=age;
        this.sex=sex;
        this.activity=activity;
        activityModifier = new activityBridge().getVal(activity);
        sexModifier = new sexBridge().getVal(sex);
        

    }
    public double calculate(){
        double result=0;
        Console.WriteLine(sexModifier.implement(0));
        Console.WriteLine(activityModifier.implement(1));
        result=sexModifier.implement(result) - 5*age+6.25*height+10*weight;
        result*=activityModifier.implement(result);
        return result;
    }

}
class activityBridge{
    private ActivityImplementor activityImplementor;
    public ActivityImplementor getVal(int choise){
        if(choise==0){
            activityImplementor = new MinorActivityImplementor();
        }else if(choise==1){
            activityImplementor=new MediumActivityImplementor();
        }else{
            activityImplementor = new IntensiveActivityImplementor();
        }
        return activityImplementor;
    }
}
class sexBridge{
    private SexImplementor sexImplementor;
    public SexImplementor getVal(bool choise){
        if (choise==true){
            sexImplementor=new MaleSexImplementor();
        }else{
            sexImplementor=new FemaleSexImplementor();
        }
        return sexImplementor;
    }
}
 abstract class ActivityImplementor{
    public static double multiplier;
    
    protected ActivityImplementor(double val){
        multiplier=val;
    }
    public double implement(double val){
        return val*multiplier;
    }
}
class IntensiveActivityImplementor : ActivityImplementor{
    public IntensiveActivityImplementor():base(1.2){

    }
}
class MediumActivityImplementor : ActivityImplementor{
    public MediumActivityImplementor():base(1){

    }
}
class MinorActivityImplementor : ActivityImplementor{
    public MinorActivityImplementor():base(0.8){

    }
}

abstract class SexImplementor{
    protected SexImplementor(int val){
        baseValue=val;
    }
 public int baseValue=0;
    
    public double implement(double val){
        return val+baseValue;
    }
}
class MaleSexImplementor : SexImplementor{
    public MaleSexImplementor():base(161){

    }
}
class FemaleSexImplementor : SexImplementor{
    public FemaleSexImplementor():base(-10){

    }
}

