%% Exercise 13.1.a: Prisoner.s dilemma with multiple rounds.
clear all, clc,clf

n=0:10;
m=6;
nRounds=10;
S = 1.5;
R=0.5;
yearsInprison=zeros(1,length(n));

for j=1:length(n)
    n1=n(j);
    yearsInprison(j)=Play1vs1(n1,m,nRounds,R,S);
end

plot(n,yearsInprison,'o','MarkerFaceColor',[0.5,0.5,0.5])
xlabel('n');
ylabel('Years in prison');
hold on
plot([6 6 6],[6 7 9],'--')

%% Exercise 13.1.b: Prisoner.s dilemma with multiple rounds.
clear all, clc,clf
hold off
n=0:10;
m=0:10;
nRounds=10;
T = 0; S = 1.5;
R = 0.7; P = 1; %both defect P both cop R

yearsInprison=zeros(length(m),length(n));
for k=1:length(m)
    m1=m(k);
    for i=1:length(n)
        n1=n(i);
        yearsInprison(i,k)=Play1vs1(n1,m1,nRounds,R,S);
    end
end

h=heatmap(yearsInprison);
h.XDisplayLabels = {'0','1','2','3','4','5','6','7','8','9','10'};
h.YDisplayLabels = {'0','1','2','3','4','5','6','7','8','9','10'};
xlabel('m');
ylabel('n');
title('Years in prison');
%plot(n,yearsInprison,'o','MarkerFaceColor',[0.5,0.5,0.5])

%% Exercise 13.2.a:  Patterns in evolutionary games
clear all, clc, clf

latticeSize=50;
nRounds=7;

R=0.9; %When R between 0.9 and 0.928 defectors will spread as  line
%  above 0.928 defectors will spread among all prisoners
%  below 0.9 everyone will coop

yearsInprison=zeros(latticeSize);

%%%%%%  Exercise 13.2.a lattice full of cooperators and place a single defector in the middle %%%%%%%%%%
%strategies=(zeros(latticeSize)+1)*nRounds; % n=0 is defect n=7 is coOp
%strategies(round(latticeSize / 2),round(latticeSize / 2))=0;
%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%%%%%  Exercise 13.2.b For different initial deffectors %%%%%%%%%%
% startpoint=round(latticeSize / 4);
% strategies(startpoint,startpoint)=0;
% strategies(2*startpoint,2*startpoint)=0;
% strategies(3*startpoint,3*startpoint)=0;
% strategies(4*startpoint,4*startpoint)=0;
%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%%%%%  Exercise 13.2.c  single cooperator in a lattice of defectors %%%%%%%%%%
 %strategies=zeros(latticeSize);
 %strategies(round(latticeSize / 2),round(latticeSize / 2))=1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%%%%%  Exercise 13.2.d  range of R when a cluster of cooperators in a background of defectors %%%%%%%%%%
strategies=zeros(latticeSize); % n=0 is defect n=1 is coOp
strategies(latticeSize/2 -latticeSize/10:latticeSize/2 +latticeSize/10,latticeSize/2 -latticeSize/10:latticeSize/2 +latticeSize/10)=1;
R=0.82; %0.82 deffectors Vanish,0.86 stable coop does not Spread
%%%%%%%%%%%%%%%%%%%%%%%%%%%
S=1.5;
length(nonzeros(strategies))

strategiesNew=strategies;
figure(2)
image(strategies,'CDataMapping','scaled')
figure(1)
for update=1:latticeSize
    for i=1:latticeSize
        for j=1:latticeSize

            yearsInprison(i,j)=PlayLattice(strategies,i,j,nRounds,R,S);
        end
    end
    for i=1:latticeSize
        for j=1:latticeSize
            pos=GetLeastYearsPosition2(yearsInprison,i,j);
            strategiesNew(i,j)=strategies(pos(1),pos(2));
        end
    end
    strategies=strategiesNew;
    subplot(1,2,2)
    image(strategies,'CDataMapping','scaled')
    pause(0.2)
end
figure(1)
subplot(1,2,1)
h=heatmap(yearsInprison);
title('Years in prison for each prisoner');

subplot(1,2,2)
image(strategies,'CDataMapping','scaled')

length(nonzeros(strategies))

%% Exercise 13.3:  Patterns in evolutionary games
clear all, clc, clf
mu=0;
latticeSize=50;
nRounds=7;

yearsInprison=zeros(latticeSize);

%%%%%%  Exercise 13.3.a+b+c +d %%%%%%%%%%
strategies=round(rand(latticeSize))*nRounds; % n=0 is defect n=7 is coOp
R=0.84; %With R <= 0.83, the cooperation dominates
%With R = 0.84 -> 0.85, cooperation coexists with defection
%With R >= 0.86 , the cooperation vanishes
%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%%%%%  Exercise 13.3.e %%%%%%%%%%
S=1.4;  %With S <= 1.3, the cooperation dominates
%With S = 1.4 -> ,1.6 cooperation coexists with defection
%With S >= 1.7 , the cooperation vanishes
%%%%%%%%%%%%%%%%%%%%%%%%%%%

strategiesNew=strategies;
figure(2)
image(strategies,'CDataMapping','scaled')

for update=1:latticeSize
    for i=1:latticeSize
        for j=1:latticeSize
            yearsInprison(i,j)=PlayLattice(strategies,i,j,nRounds,R,S);
        end
    end
    for i=1:latticeSize
        for j=1:latticeSize
            pos=GetLeastYearsPosition2(yearsInprison,i,j);
            strategiesNew(i,j)=strategies(pos(1),pos(2));

            if rand<mu
                strategiesNew(i,j)=round(rand);
            end

        end
    end
    strategies=strategiesNew;

end
figure(1)
subplot(1,2,1)
h=heatmap(yearsInprison);

subplot(1,2,2)
image(strategies,'CDataMapping','scaled')

length(nonzeros(strategies))

%% Exercise 13.4:  Patterns in evolutionary games
clear all, clc, clf
mu=0.01;
latticeSize=30;
nRounds=7;

yearsInprison=zeros(latticeSize);
stats=zeros(nRounds,latticeSize);
strategies= round( (nRounds)*(rand(latticeSize))); % n=0 is defect n=1 is coOp

%%%%%%  Exercise 13.4.a+b %%%%%%%%%%
R=0.72; %With R <= 0.61, the cooperation dominates
%With R = 0.62 -> 0.72, cooperation coexists with defection
%With R >= 0.73 , the cooperation vanishes
%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%%%%%  Exercise 13. %%%%%%%%%%
S=1.5;  %With S <= 1.3, the cooperation dominates
%With S = 1.4 -> ,1.6 cooperation coexists with defection
%With S >= 1.7 , the cooperation vanishes
%%%%%%%%%%%%%%%%%%%%%%%%%%%

length(nonzeros(strategies))
strategiesNew=strategies;
% figure(2)
% image(strategies*36)
figure(1)
for update=1:50
    for i=1:latticeSize
        for j=1:latticeSize
            yearsInprison(i,j)=PlayLattice(strategies,i,j,nRounds,R,S);
        end
    end

    %%%%%%% Update Strategies %%%%%%%%%%%
    for i=1:latticeSize
        for j=1:latticeSize
            pos=GetLeastYearsPosition2(yearsInprison,i,j);
            strategiesNew(i,j)=strategies(pos(1),pos(2));
            if rand<mu
                strategiesNew(i,j)=round(nRounds* rand);
            end
        end
    end
    strategies=strategiesNew;

    %%%%%%% Plot Strategies %%%%%%%%%%%
    subplot(1,2,1)
 %   hold off
    legend clear
    for n=0:nRounds
        hold on

        stats(n+1,update)=length(find(strategies==n));
        stats2=stats/numel(strategies);

        name=append('n = ',num2str(n));
        color={'b', 'c', 'r', 'g', 'm', 'k', [0.8500 0.3250 0.0980], 'y'};
        p=plot(1:update,stats2(n+1,1:update),Color=color{n+1});
        set(p,'DisplayName',name)
        legend('Location','best')
    end

    hold off
    subplot(1,2,2)
    %heatmap(strategies,'Colormap',spring)
    image(strategies,'CDataMapping','scaled')
    colorbar
    pause(0.1)
end


subplot(1,2,2)
%heatmap(strategies,'Colormap',spring)
image(strategies,'CDataMapping','scaled')
colorbar

menastats= mean(stats,2)
sum(menastats(1:4))
sum(menastats(5:8))

%% Exercise 13.5:  Two-dimensional phase map of evolutionary games.
clear all, clc, clf
mu=0.01;
latticeSize=30;
nRounds=7;

yearsInprison=zeros(latticeSize);
stats=zeros(nRounds,latticeSize);
strategies= round( (nRounds)*(rand(latticeSize))); % n=0 is defect n=7 is coOp

%%%%%%  Exercise 13.4.a+b %%%%%%%%%%
R=0.4; %With R <= 0.5, the cooperation dominates
%With R = 0.51 -> 0.72, cooperation coexists with defection
%With R >= 0.73 , the cooperation vanishes
%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%%%%%  Exercise 13. %%%%%%%%%%
S=1.5;  %With S <= 1.3, the cooperation dominates
%With S = 1.4 -> ,1.6 cooperation coexists with defection
%With S >= 1.7 , the cooperation vanishes
%%%%%%%%%%%%%%%%%%%%%%%%%%%

length(nonzeros(strategies))
strategiesNew=strategies;
% figure(2)
% image(strategies*36)
figure(1)
for update=1:500
    for i=1:latticeSize
        for j=1:latticeSize
            yearsInprison(i,j)=PlayLattice(strategies,i,j,nRounds,R,S);
        end
    end

    %%%%%%% Update Strategies %%%%%%%%%%%
    for i=1:latticeSize
        for j=1:latticeSize
            pos=GetLeastYearsPosition2(yearsInprison,i,j);
            strategiesNew(i,j)=strategies(pos(1),pos(2));
            if rand<mu
                strategiesNew(i,j)=round(nRounds* rand);
            end
        end
    end
    strategies=strategiesNew;

    %%%%%%% Plot Strategies %%%%%%%%%%%
    subplot(1,2,1)
    hold off
    legend clear

    for n=0:nRounds
        hold on

        stats(n+1,update)=length(find(strategies==n));
        stats2=stats/numel(strategies);
        if update>=490
            name=append('n = ',num2str(n));
            color={'b', 'c', 'r', 'g', 'm', 'k', [0.8500 0.3250 0.0980], 'y'};
            p=plot(1:update,stats2(n+1,1:update),Color=color{n+1});
            set(p,'DisplayName',name)
            legend('Location','best')
            pause(0.1)
        end
    end
    hold off
    %     subplot(1,2,2)
    %     %heatmap(strategies,'Colormap',spring)
    %     image(strategies,'CDataMapping','scaled')
    %     colorbar
    %     %pause(0.1)
end


subplot(1,2,2)
%heatmap(strategies,'Colormap',spring)
image(strategies,'CDataMapping','scaled')
colorbar

meanStats= mean(stats,2);
varStats=var(stats(:,100:500),0,2)
% varStats =
%    1.0e+03 *
%     8.4768
%     7.5639
%     7.0124
%     4.3314
%     5.5958
%     8.2926
%     7.4634
%     4.1917