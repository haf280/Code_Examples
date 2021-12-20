function evaluation = EvaluateParticles(positions)

nParticles =size(positions,1);
evaluation=zeros(nParticles,1);

for i=1:nParticles

    x=positions(i,1);
    y=positions(i,2);

    term1 = (x^2 + y -11)^2;
    term2 = (x+ y^2 - 7)^2;

    evaluation(i) = term1 + term2;
end

end