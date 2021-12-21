%% 11.1 Agent-based SIR Model
clc, clear all, clf
nAgents=1000;
latticeSize=100;
% With hight recover rate(10%) it is difficult to infect the population
recoveryRate=0.01;
% with 7% infection rate the majority of the population will get infected
infectionRate=0.005;
d=0.8;
time=500;
stats=zeros(4,time);

%Initiliaze Lattice
lattice=InitLattice(latticeSize,nAgents);

%while(length(find(lattice==2))>0)
for t=1:time    
    subplot(1,2,2), cla
    for i=1:latticeSize
        for j=1:latticeSize
            if rand<=d && lattice(i,j)>0
                m=MoveAgent(lattice,i,j);
                if lattice(m(1),m(2))==0
                    lattice(m(1),m(2))=lattice(i,j);
                    lattice(i,j)=0;
                end
            end
            
            if lattice(i,j)==2
                if rand<=recoveryRate
                    lattice(i,j)=3;
                elseif  rand<=infectionRate
                    lattice=InfectAgents(lattice,i,j);
                end
            end
        end
    end
    
    stats(1,t)=length(find(lattice==1));
    stats(2,t)=length(find(lattice==2));
    stats(3,t)=length(find(lattice==3));
    %    image(lattice,'CDataMapping','scaled')
    %if(t<100)
    subplot(1,2,1)
    cla
    [row,col] = find(lattice==1);
    plot(row,col,'.','Color','b')
    hold on
    [row,col] = find(lattice==2);
    plot(row,col,'.','Color','r')
    [row,col] = find(lattice==3);
    plot(row,col,'.','Color','g')
    %end
    
    subplot(1,2,2)
    plot(1:time,stats(1,:),'Color','b')
    hold on
    plot(1:time,stats(2,:),'Color','r')
    plot(1:time,stats(3,:),'Color','g')
    legend('Healthy','Infected','Recoverd','Location','best')
    xlabel('Time')
    ylabel('Number of agents')
    pause(0.01)
end



%% Exercise 11.2: Dependence of the final number of recovered agents on the infection rate
clc, clear all, clf
nAgents=1000;
latticeSize=100;
% With high recover rate(10%) it is difficult to infect the population
% with 7% infection rate the majority of the population will get infected

d=0.4;
time=800;
stats=zeros(3,time);
%Initiliaze Lattice
lattice=InitLattice(latticeSize,nAgents);

beta=linspace(0,1,20);
gamma=[0.01 0.02];
RInf=zeros(1,length(beta));
Ravg=zeros(1,length(beta));
latticeCopy=lattice;

for g=1:2
    recoveryRate=gamma(g);
    for b=1:length(beta)
        infectionRate=beta(b);
        for repeat=1:10 %%%%%%%%%%%%%%%%%%%
            lattice=latticeCopy;
            for t=1:time
                
                for i=1:latticeSize
                    for j=1:latticeSize
                        if rand<=d && lattice(i,j)>0
                            m=MoveAgent(lattice,i,j);
                            if lattice(m(1),m(2))==0
                                lattice(m(1),m(2))=lattice(i,j);
                                lattice(i,j)=0;
                            end
                        end
                        
                        if lattice(i,j)==2
                            if rand<=recoveryRate
                                lattice(i,j)=3;
                            elseif  rand<=infectionRate
                                lattice=InfectAgents(lattice,i,j);
                            end
                        end
                    end
                end
                
                stats(1,t)=length(find(lattice==1));
                stats(2,t)=length(find(lattice==2));
                stats(3,t)=length(find(lattice==3));
                
            end
            RInf(repeat,b)=stats(3,time);
            
        end
        
    end
    Ravg(g,:)=mean(RInf);
    plot(beta,Ravg(g,:),'.','MarkerSize',10)
    hold on
    pause(0.01)
    
end
legend(['\gamma = ',num2str(0.01)],num2str(0.02),'Location','best')
xlabel('\beta Infection rate')
ylabel('R\infty')

%% 11.2 b
figure
plot(beta./0.01,Ravg(1,:),'.','MarkerSize',10)
hold on
plot(beta./0.02,Ravg(2,:),'.','MarkerSize',10)
legend(num2str(0.01),num2str(0.02),'Location','best')
xlabel('\beta/\gamma')
ylabel('R\infty')

%% Exercise 11.3: SIR model with mortality.
clc, clear all, clf
nAgents=1000;
latticeSize=100;
% With hight recover rate(10%) it is difficult to infect the population
recoveryRate=0.01;
% with 7% infection rate the majority of the population will get infected
infectionRate=0.6;
%between 5% and 15% death rate the Disease will c becomes most severe
deathRate=0.1;
d=0.8;
time=800;
stats=zeros(4,time);


%Initiliaze Lattice
lattice=InitLattice(latticeSize,nAgents);

death=0;
deaths=zeros(1,time);
%while(length(find(lattice==2))>0)
for t=1:time
    
    subplot(1,2,2)
    cla
    for i=1:latticeSize
        for j=1:latticeSize
            if rand<=d && lattice(i,j)>0
                m=MoveAgent(lattice,i,j);
                if lattice(m(1),m(2))==0
                    lattice(m(1),m(2))=lattice(i,j);
                    lattice(i,j)=0;
                end
            end
            
            if lattice(i,j)==2
                if  rand<=infectionRate
                    lattice=InfectAgents(lattice,i,j);
                elseif rand<=recoveryRate
                    lattice(i,j)=3;
                elseif rand<=deathRate
                    lattice(i,j)=-1;
                    death=death+1;
                end
            end
        end
        %image(lattice,'CDataMapping','scaled')
    end
    deaths(t)=death;
    stats(1,t)=length(find(lattice==1));
    stats(2,t)=length(find(lattice==2));
    stats(3,t)=length(find(lattice==3));
    stats(4,t)=length(find(lattice==-1));
    
    
end
subplot(1,2,1)
cla
[row,col] = find(lattice==1);
plot(row,col,'.','Color','b')
hold on
[row,col] = find(lattice==2);
plot(row,col,'.','Color','r')
[row,col] = find(lattice==3);
plot(row,col,'.','Color','g')
[row,col] = find(lattice==-1);
plot(row,col,'.','Color','black')

subplot(1,2,2)
plot(1:time,stats(1,:),'Color','b')
hold on
plot(1:time,stats(2,:),'Color','r')
plot(1:time,stats(3,:),'Color','g')
plot(1:time,stats(4,:),'Color','black')
legend('Healthy','Infected','Recoverd','Dead','Location','best')
xlabel('Time')
ylabel('Number of agents')
pause(0.01)
%% Exercise 11.4: SIR model with temporary immunity
clc, clear all, clf
nAgents=1000;
latticeSize=100;
% With hight recover rate(10%) it is difficult to infect the population
% with 7% infection rate the majority of the population will get infected
%between 5% and 15% death rate the Disease will c becomes most severe

recoveryRate=0.2;
infectionRate=0.8;
deathRate=0.1;

alpha=0.7;% Mortality rate
d=0.8;
time=1000;
stats=zeros(4,time);


%Initiliaze Lattice
lattice=InitLattice(latticeSize,nAgents);

death=0;
deaths=zeros(1,time);
susceptible=0;
susceptibles=zeros(1,time);
%while(length(find(lattice==2))>0)
for t=1:time
    
    subplot(1,2,2)
    cla
    for i=1:latticeSize
        for j=1:latticeSize
            if rand<=d && lattice(i,j)>0
                m=MoveAgent(lattice,i,j);
                if lattice(m(1),m(2))==0
                    lattice(m(1),m(2))=lattice(i,j);
                    lattice(i,j)=0;
                end
            end
            
            if lattice(i,j)==2
                if  rand<=infectionRate
                    lattice=InfectAgents(lattice,i,j);
                elseif rand<=recoveryRate
                    lattice(i,j)=3;
                elseif rand<=deathRate
                    lattice(i,j)=-1;
                    death=death+1;
                end
            end
            
            if lattice(i,j)==3
                if  rand<=alpha
                    lattice(i,j)=1;
                    susceptible=susceptible+1;
                end
            end
        end
        
    end
    deaths(t)=death;
    susceptibles(t)=susceptible;
    stats(1,t)=length(find(lattice==1));
    stats(2,t)=length(find(lattice==2));
    stats(3,t)=length(find(lattice==3));
    stats(4,t)=length(find(lattice==-1));
    
    
end

subplot(1,2,1)
cla
[row,col] = find(lattice==1);
plot(row,col,'.','Color','b')
hold on
[row,col] = find(lattice==2);
plot(row,col,'.','Color','r')
[row,col] = find(lattice==3);
plot(row,col,'.','Color','g')
[row,col] = find(lattice==-1);
plot(row,col,'.','Color','black')

subplot(1,2,2)
plot(1:time,stats(1,:),'Color','b')
hold on
plot(1:time,stats(2,:),'Color','r')
plot(1:time,stats(3,:),'Color','g')
plot(1:time,stats(4,:),'Color','black')
plot(1:time,susceptibles,'Color','yellow')
legend('Healthy','Infected','Recoverd','Dead','Susceptible','Location','best')
xlabel('Time')
ylabel('Number of agents')
pause(0.01)


