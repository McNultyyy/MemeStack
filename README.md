# MemeStack

### Build the docker image
`docker build -t mcnultyyy/MemeStack:latest . `

### Deploy to cluster

#### Initial
`helm install --values=chart/values.yaml webapi ./chart`

#### Updates
`helm update --values=chart/values.yaml webapi ./chart`

### Istio
`istioctl install --set values.kiali.enabled=true --set profile=demo`
`kubectl label namespace default istio-injection=enabled`

#### Dashboard
`istioctl dashboard kiali`

----
`kubectl create namespace istio-system`

`helm template install/kubernetes/helm/istio-init --name istio-init --namespace istio-system | kubectl apply -f -`

`kubectl get crds | grep 'istio.io' | wc -l`

`helm template install/kubernetes/helm/istio --name istio --namespace istio-system | kubectl apply -f -`