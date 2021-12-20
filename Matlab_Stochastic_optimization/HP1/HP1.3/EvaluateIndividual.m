% First compute the function value, then compute the fitness
% value; see also the problem formulation.

function fitness = EvaluateIndividual(x)
x1=x(1);
x2=x(2);

term1 = (1.5 -x1 +x1*x2)^2;
term2 = (2.25 - x1+ x1*x2^2)^2;
term3 = (2.625 - x1 +x1*x2^3)^2;

g= term1+term2+term3;

fitness = 1/g;

end
