﻿module AlvisSpec

type ValueType =   
    | Int of int  
    | Float of float  
    | String of string 
    | Bool of bool

type ValueName = {
    Value : ValueType;
    Name : string;
} 
    
     
type Op = Eq | Gt | Ge | Lt | Le | Ne   // = > >= <  <= /=

type Port = In of string | Out of string

type Guard =
    | Cond of (ValueType * Op * ValueType) 
    | Const of bool


type Loop = {
        Ports : Port list ;
        Exit : bool;
}

type  Condition = {
        Guard : Guard;
        ConditionBody :  ConditionBody;
        ElseConditionBody :  ConditionBody option;
}

and ConditionBody ={
    Looping : Loop option;
    Ports : Port list ;
    Condition : Condition list;
    EXIT : bool;
}

type Proc = {
    Condition : Guard option;
    Port :  string;
    ProcBody : ConditionBody
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




