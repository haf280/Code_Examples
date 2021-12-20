% This function should run gradient descent until the L2 norm of the
% gradient falls below the specified threshold.

function x = RunGradientDescent(xStart, mu, eta, gradientTolerance)

gradientValue = ComputeGradient(xStart,mu);
normGradient = norm(gradientValue);
x=xStart;

while (normGradient > gradientTolerance)
  x = x - eta * gradientValue;
  gradientValue = ComputeGradient(x,mu);
  normGradient = norm(gradientValue);   
end

end


