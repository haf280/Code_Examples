% This function should return the gradient of f_p = f + penalty.
% You may hard-code the gradient required for this specific problem.

function gradF = ComputeGradient(x,mu)


constarintValue = x(1)^2 +x(2)^2 -1;
x1=x(1);
x2=x(2);

if constarintValue > 0
    gradF(1) = 2*(x1-1) + mu *4*x1 * (x1^2+x2^2 - 1);
    gradF(2) = 4*(x2-2) + mu* 4*x2 * (x1^2+x2^2 - 1);
else 
    gradF(1) = 2*(x1-1);
    gradF(2) = 4*(x2-2);

end



end


