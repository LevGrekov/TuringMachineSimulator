# TuringMachineSimulator

Программа нужна чтобы отслеживать ход машины Тюринга при подсчете функций:

Например, можно подсчитать функцию [1/(x-3)] + y.

Вот программы, задающие эту функцию:

q1 1 q2 0 R

q2 1 q3 0 R

q3 1 q4 0 R

q4 1 q5 0 R

q5 1 q6 0 R

q6 0 q0 0 S

q6 1 q7 0 R

q7 1 q7 0 R

q7 0 q8 0 R

q8 1 q0 0 S

q2 0 q9 0 R

q9 1 q10 0 R

q10 0 q10 0 S

q10 1 q0 0 S

q3 0 q9 0 R

q4 0 q9 0 R

q5 0 q5 0 S

Используя их, мы можем отслеживать ход работы алгоритма.

Ещё пример: f(x,y) = ( 2 + x ) / ( 2 - x )
q1 1 q1 1 R

q1 0 q2 0 R

q2 1 q3 0 R

q3 0 q4 0 L

q4 0 q4 0 L

q4 1 q5 1 L

q5 1 q6 0 L

q6 1 q5 1 L

q5 0 q0 0 S

q6 0 q6 0 S

q3 1 q7 1 R

q7 1 q7 1 S

q7 0 q8 0 L

q8 1 q8 1 L

q8 0 q9 0 L

q9 1 q9 1 L

q9 0 q0 0 S
