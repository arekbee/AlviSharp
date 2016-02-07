module AlvisSpec

type ValueType =   
    | Int of int  
    | Float of float  
    | String of string 


type ValueName = {
    Value : ValueType;
    Name : string;
} 
    
     
type Op = Eq | Gt | Ge | Lt | Le | Ne   // = > >= <  <= /=

type Port = 
    | In of string * ValueType option
    | Out of string * ValueType option

type Guard =
    | Cond of (ValueType * Op * ValueType) 
    | Const of bool


type Assign =   ValueName




type Loop = {
        Ports : Port list ;
        Exit : bool;
        Select : SelectStatement list;
        Condition : Condition list;
}

and  Condition = {
        Guard : Guard;
        ConditionBody :  ConditionBody;
        ElseConditionBody :  ConditionBody option;
}

and ConditionBody ={
    Looping : Loop option;
    Ports : Port list ;
    Condition : Condition list;
    Assign : Assign list;
    Exit : bool;
    Null : bool;
}

and Alt =   Condition

and SelectStatement = {
    Alt : Alt list;
}

type Proc = {
    Condition : Guard option;
    Port : string;
    ProcBody : ConditionBody;
}



type  Agent = {
    Proc : Proc list;
    Values : ValueName list;
    Looping : Loop option;
    Ports : Port list ;
    Condition : Condition list;
    Null : bool;
}




type AlvisStatement = {   
        AgentList : string list;   
        AgentBody :  Agent;
}

  type  Agents =  AlvisStatement list




