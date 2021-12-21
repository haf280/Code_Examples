%% EX.5.1 equal probability
clc, clear all, clf
for runs=1:1000
    x=zeros(1,1000);
    for i=2:1000
        r=rand;
        if r<0.5
            x(i)=x(i-1)-1;
        else
            x(i)=x(i-1)+1;
        end
    end

    y=1:1000;
    subplot(2,3,1)
    %plot(x,y,'.','Markersize',0.001,'Color','b')
    plot(x,y)
    hold on
    x1000(runs)=x(1000);
end
subplot(2,3,4)
hist(x1000)

%%% EX.5.1 Gaussian distribution
clc, clear all,
gm = gmdistribution(0,1);

for runs=1:1000
    x=zeros(1,1000);
    r = random(gm,1000);
    for i=2:1000
        x(i)=x(i-1)+r(i);
    end
    y=1:1000;

    subplot(2,3,2)
    %plot(x,y,'.','Markersize',0.001,'Color','r')
    plot(x,y)
    hold on
    x1000(runs)=x(1000);
end
subplot(2,3,5)
hist(x1000)

%%% EX.5.1 Equal probabilities of being [1, (1 -sqrt(3))/2, (1+ sqrt(3))/2]
clc, clear all
for runs=1:1000
    x=zeros(1,1000);
    for i=2:1000
        r=rand;
        if r<1/3
            x(i)=x(i-1)-1;
        elseif r<2/3
            x(i)=x(i-1)+(1-sqrt(3))/2;
        else
            x(i)=x(i-1)+(1+sqrt(3))/2;
        end
    end
    y=1:1000;
    subplot(2,3,3)
    %plot(x,y,'.','Markersize',0.001,'Color','g')
    plot(x,y)
    hold on
    x1000(runs)=x(1000);
end
subplot(2,3,6)
hist(x1000)
% All the steps have the same mean 0) and variance = 1)
%% EX 5.2 a): Discrete white noise
clc,clear all ,clf
gm = gmdistribution(0,1);

deltaT=[0.01 0.05 0.1];

for t=1:3
    for runs=1:50
        delta=deltaT(t);
        x=zeros(1,5/delta);
        r = random(gm,1000);
        for i=2:length(x)
            x(i)=x(i-1)+sqrt(delta)*r(i);
        end

        y=0:delta:4.99999;
        subplot(2,3,t)
        plot(y,x)
        title(['delta t = ' num2str(delta)])
        hold on
    end
    xlabel('t(s)');
    ylabel('x(t)');
    axis([0 5 -inf inf])
end


%% EX 5.2 b)Fast code
clc,clear all

gm = gmdistribution(0,1);
deltaT=[0.01 0.05 0.1];

for t=1:3
    delta=deltaT(t);
    displacement= zeros(1e4,5/delta);
    for i=2:size(displacement,2)
        displacement(:,i)=displacement(:,i-1)+sqrt(delta)*random(gm,1e4);
    end
    y=0:delta:4.99999;
    MSD=mean(displacement.^2);
    subplot(2,3,t+3)
    plot(y,MSD,'LineWidth',3)
    hold on
    plot([0 5],[0 5],'r--','LineWidth',2)
    xlabel('t(s)');
    ylabel('<x(t)^2>');
    axis([0 5 0 5])
end


%% EX 5.2 b) Slow code
% clc,clear all ,clf
% gm = gmdistribution(0,1);
%
% deltaT=[0.01 0.05 0.1];
%
% for t=1:3
%     displacement= zeros(1e4,5/delta);
%     for runs=1:1e4
%         delta=deltaT(t);
%         x=zeros(1,5/delta);
%         r = random(gm,1000);
%         for i=2:length(x)
%             x(i)=x(i-1)+sqrt(delta)*r(i);
%             displacement(runs,i)=x(i);
%         end
%
%     end
%     y=0:delta:4.99999;
%     MSD=mean(displacement.^2);
%     subplot(1,3,t)
%     plot(y,MSD,'LineWidth',3)
% end

%% Exercise 5.3: Brownian motion in inertial and viscous regimes
clc, clear all, clf
gm = gmdistribution(0,1);
R=1e-6; m=1.11*1e-14; yta=0.001;
gamma=6*pi*yta*R; T=300;
tau=m/gamma; %Choose tau
deltaT=0.01*tau; duration2=100*tau;
kB = physconst('Boltzmann');
x=zeros(1,round(tau/deltaT));
x2=zeros(1,round(tau/deltaT));
r=random(gm,100*tau/deltaT);
for i=3:tau/deltaT
    % With mass Eq5.6
    term1=(2+deltaT*(gamma/m))*(x(i-1))/((1+deltaT*(gamma/m)));
    term2=x(i-2)/(1+deltaT*(gamma/m));
    term3=(sqrt(2*kB*T*gamma))*((deltaT)^(3/2))*(r(i))/(m*(1+deltaT*(gamma/m)));
    x(i)=term1-term2+term3;
    % Without mass Eq5.7
    x2(i)=x2(i-1)+sqrt(2*kB*T*deltaT/gamma)*r(i);
end

time=linspace(0,1,length(x));
subplot(1,3,1)
plot(time,x,'--')
hold on
plot(time,x2)

%
disWInit=zeros(100,100*tau/deltaT);
disOInit=zeros(100,100*tau/deltaT);
x=zeros(1,round(tau/deltaT));
x2=zeros(1,round(tau/deltaT));

for i=3:100*tau/deltaT
    % With mass Eq5.6
    term1=(2+deltaT*(gamma/m)).*(x(i-1))./((1+deltaT*(gamma/m)));
    term2=x(i-2)./(1+deltaT*(gamma/m));
    term3=(sqrt(2*kB*T*gamma))*((deltaT)^(3/2))*(r(i))/(m*(1+deltaT*(gamma/m)));
    x(i)=term1-term2+term3;
    % Without mass Eq5.7
    x2(i)=x2(i-1)+sqrt(2*kB*T*deltaT/gamma)*r(i);
    disWInit(runs,i)=x(i);
    disOInit(runs,i)=x2(i);
end

time=linspace(0,100,length(x));
subplot(1,3,2) % I should have averaged one very long trajectory
plot(time,x,'--')
hold on
plot(time,x2)
MsdIner=mean(disWInit.^2);
MsdWOIner=mean(disOInit.^2);
subplot(1,3,3)
plot(time,MsdIner,'.')
hold on
plot(time,MsdWOIner,'--')

%% Exercise 5.4: Optically trapped Brownian particle.

clc, clear all, clf
gm = gmdistribution(0,1);
R=1e-6; yta=0.001;
gamma=6*pi*yta*R; T=300;

kB = physconst('Boltzmann');
kx = 1e-6;
ky = 5e-7;
dt = 1e-3 ;
runs=1e5;
x=zeros(1,runs);
y=zeros(1,runs);
Wx=random(gm,runs);
Wy=random(gm,runs);
px=zeros(1,runs);
py=zeros(1,runs);

for i=2:runs
    x(i) = x(i-1) - kx*x(i-1).*dt./gamma + sqrt(2*kB*T*dt/gamma)*Wx(i-1);
    y(i) = y(i-1) - ky*y(i-1).*dt./gamma + sqrt(2*kB*T*dt/gamma)*Wy(i-1);
    px(i)=exp(-(0.5*kx*x(i).^2)/(kB*T));
    py(i)=exp(-(0.5*ky*y(i).^2)/(kB*T));

end
subplot(1,3,1)
plot(x,y,'.','MarkerSize',1)

subplot(1,3,2)
plot(x,px,'.')
hold on
plot(y,py,'.')

% xCounts=hist(x,runs);
% xprob=xCounts/runs;
% plot(x,xprob,'.')
% subplot(1,3,3)
% %pdf(x)

t=0:0.005:0.3;
cx=zeros(1,length(t));
cy=zeros(1,length(t));
for i=1:length(t)
    cx(i)=kB*T*exp(-kx*t(i)/gamma)/kx;
    cy(i)=kB*T*exp(-ky*t(i)/gamma)/ky;

end
subplot(1,3,3)
plot(t,cx)
hold on
plot(t,cy)
%