% Note: Each component of x should take values in [-a,a], where a = maximumVariableValue.

function x = DecodeChromosome(chromosome,numberOfVariables,maximumVariableValue)

nGenes = size(chromosome,2);
genesPerVariable  = fix(nGenes/numberOfVariables);
jj=1;

for variable= 1:numberOfVariables  
    x(variable) = 0.0;

    for j = 1:genesPerVariable
        x(variable) = x(variable) + chromosome(jj)*2^(-j);
        jj= jj+1;
    end
    x(variable) = -maximumVariableValue + 2*maximumVariableValue*x(variable)/(1 - 2^(-genesPerVariable));

end

end

