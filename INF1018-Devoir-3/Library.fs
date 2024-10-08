namespace INF1018_Devoir_3

open System
open System.Collections.Generic

(* 
Considerez la grammaire d'arithmétique simple suivante :

expression -> var | int
expression -> expression op expression
op         -> + | - | * | /

Construisez un interpréteur pour cette grammaire. Votre interpreteur doit
prendre en entrée une séquence d'unité lexicales et retourner le résultat
de l'expression en sortie.
Vous devrez possiblement transformer cette grammaire pour
éliminer la récursion à gauche en premier lieu.
*)

module Interpreter =
    type Var = A | B | C
    type Op = Plus | Minus | Multiply | Divide
    type LexicalUnit = Var of Var | Int of int | Op of Op | Nil
    
    type Factor = VarFactor of Var
                | IntFactor of int
    type PartialExpression = PartialExpression of (Op * Factor * PartialExpression)
                           | EmptyExpression
    type Expression = ParenExpression of Expression
                    | FactorExpression of Factor * PartialExpression

    type State = { LexicalStack: Stack<LexicalUnit> }

    let lexPeek state = 
        if state.LexicalStack.Count > 0
        then state.LexicalStack.Peek ()
        else Nil

    let lexPop state = state.LexicalStack.Pop ()
    
    let validateNext state lexUnit =
        let next = lexPop state
        if next <> lexUnit
        then sprintf "Validation error: expected %A, got %A." lexUnit next
             |> failwith

    // Reçoit une séquence d'unité lexicales et retourne le résultat de l'expression
    // si la séquence est valide pour la grammaire. Les valeurs des variables a, b et c
    // sont aussi passées en paramètres pour le calcul.
    let interpret lexUnits a b c =
        failwith "Unimplemented."
