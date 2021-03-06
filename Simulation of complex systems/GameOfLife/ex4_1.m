%% rule 184
clc, clear all
nGeneration=30;
%rule184=[1 1 1 1 1 0 1 0 1 1 0 0 0 1 1 0 1 0 0 0 1 0 0 0];
nParticles=100;
rule184= round(rand(1,nParticles));

generations=nan(nGeneration,nParticles);
generations(1,:)=rule184;

for row=1:nGeneration-1
    
    for col=1:nParticles-1
        
        if generations(row,col+1)==0 && generations(row,col)==1
            generations(row+1,col)=0;
            generations(row+1,col+1)=1;
            
        elseif isnan(generations(row+1,col))
            generations(row+1,col)=generations(row,col);
        end
    end
    
    if generations(row,nParticles)==1 && generations(row,1)==0
        generations(row+1,nParticles)=1;
    else
        generations(row+1,nParticles)=generations(row,nParticles);
    end
    
    
end

image(generations,'CDataMapping','scaled')


%% rule 90

clc, clear all,clf
nGeneration=50;
%rule184=[1 1 1 1 1 0 1 0 1 1 0 0 0 1 1 0 1 0 0 0 1 0 0 0];
%rule90= round(rand(1,50));
nParticles=30;
rule90=zeros(1,nParticles);
rule90(nParticles/2)=1;

generations=nan(nGeneration,nParticles);
generations(1,:)=rule90;

for row=1:nGeneration-1
    generations(row+1,1)=xor(generations(row,nParticles),generations(row,2));
    
    for col=2:nParticles-1
        
        generations(row+1,col)=xor(generations(row,col-1),generations(row,col+1));
        
    end
    
    generations(row+1,nParticles)=xor(generations(row,nParticles),generations(row,1));
    
end

image(generations,'CDataMapping','scaled')
xlabel('Cell')
ylabel('Generation')

%% Rule30
clc, clear all
nGeneration=70;
nParticles=50;
rule30=zeros(1,nParticles);

rule30(nParticles/2)=1;
generations=nan(nGeneration,nParticles);
generations(1,:)=rule30;

for row=1:nGeneration-1
    a=generations(row,nParticles);
    b=generations(row,1);
    c=generations(row,2);
    
    if (a==1 && b==0 && c==0) || (a==0 && b==1 && c==1) || ...
            (a==0 && b==1 && c==0) || (a==0 && b==0 && c==1)
        generations(row+1,1)=1;
    else
        generations(row+1,1)=0;
    end
    
    for col=2:nParticles-1
        a=generations(row,col-1);
        b=generations(row,col);
        c=generations(row,col+1);
        
        if (a==1 && b==0 && c==0) || (a==0 && b==1 && c==1) || ...
                (a==0 && b==1 && c==0) || (a==0 && b==0 && c==1)
            generations(row+1,col)=1;
        else
            generations(row+1,col)=0;
        end
    end
    
    a=generations(row,nParticles-1);
    b=generations(row,nParticles);
    c=generations(row,1);
    
    if (a==1 && b==0 && c==0) || (a==0 && b==1 && c==1) || ...
            (a==0 && b==1 && c==0) || (a==0 && b==0 && c==1)
        generations(row+1,nParticles)=1;
    else
        generations(row+1,nParticles)=0;
    end
end

image(generations*100)
xlabel('Cell')
ylabel('Generation')


%% Rule 110
clc, clear all
nGeneration=70;
nParticles=200;
rule110=round(rand(1,nParticles));

rule110(nParticles/2)=1;
generations=nan(nGeneration,nParticles);
generations(1,:)=rule110;

for row=1:nGeneration-1
    a=generations(row,nParticles);
    b=generations(row,1);
    c=generations(row,2);
    
    if  (a==1 && b==1 && c==1) || ...
            (a==1 && b==0 && c==0) || (a==0 && b==0 && c==0)
        generations(row+1,1)=0;
    else
        generations(row+1,1)=1;
    end
    
    for col=2:nParticles-1
        a=generations(row,col-1);
        b=generations(row,col);
        c=generations(row,col+1);
        
        if (a==1 && b==1 && c==1) || ...
                (a==1 && b==0 && c==0) || (a==0 && b==0 && c==0)
            generations(row+1,col)=0;
        else
            generations(row+1,col)=1;
        end
    end
    
    a=generations(row,nParticles-1);
    b=generations(row,nParticles);
    c=generations(row,1);
    
    if (a==1 && b==1 && c==1) || ...
            (a==1 && b==0 && c==0) || (a==0 && b==0 && c==0)
        generations(row+1,nParticles)=0;
    else
        generations(row+1,nParticles)=1;
    end
end

image(generations,'CDataMapping','scaled')

%% new rule 1 (NAND)
clc, clear all
nGeneration=70;
nParticles=70;
rule110=round(rand(1,nParticles));

rule110(nParticles/2)=1;
generations=nan(nGeneration,nParticles);
generations(1,:)=rule110;

for row=1:nGeneration-1
    a=generations(row,nParticles);
    b=generations(row,1);
    c=generations(row,2);
    
    if  (a==1 && b==1 && c==1) || (a==0 && b==0 && c==0)
        generations(row+1,1)=0;
    else
        generations(row+1,1)=1;
    end
    
    for col=2:nParticles-1
        a=generations(row,col-1);
        b=generations(row,col);
        c=generations(row,col+1);
        
        if (a==1 && b==1 && c==1) || ...
                (a==0 && b==0 && c==0)
            generations(row+1,col)=0;
        else
            generations(row+1,col)=1;
        end
    end
    
    a=generations(row,nParticles-1);
    b=generations(row,nParticles);
    c=generations(row,1);
    
    if (a==1 && b==1 && c==1) || ...
            (a==0 && b==0 && c==0)
        generations(row+1,nParticles)=0;
    else
        generations(row+1,nParticles)=1;
    end
end

image(generations,'CDataMapping','scaled')

%% Rule AND
clc, clear all
nGeneration=70;
nParticles=70;
rule110=round(rand(1,nParticles));

rule110(nParticles/2)=1;
generations=nan(nGeneration,nParticles);
generations(1,:)=rule110;

for row=1:nGeneration-1
    a=generations(row,nParticles);
    b=generations(row,1);
    c=generations(row,2);
    
    if  (a==1 && b==1 && c==1) || ...
            (a==0 && b==0 && c==0)
        generations(row+1,1)=1;
    else
        generations(row+1,1)=0;
    end
    
    for col=2:nParticles-1
        a=generations(row,col-1);
        b=generations(row,col);
        c=generations(row,col+1);
        
        if (a==1 && b==1 && c==1) || ...
                (a==0 && b==0 && c==0)
            generations(row+1,col)=1;
        else
            generations(row+1,col)=0;
        end
    end
    
    a=generations(row,nParticles-1);
    b=generations(row,nParticles);
    c=generations(row,1);
    
    if (a==1 && b==1 && c==1) || ...
            (a==0 && b==0 && c==0)
        generations(row+1,nParticles)=1;
    else
        generations(row+1,nParticles)=0;
    end
end

image(generations,'CDataMapping','scaled')
