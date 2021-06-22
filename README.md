# Bfam_rfqPricer
RfqPricerOrchestrator

## Next steps: 
- I beleieve, the pricing time is the longest for the orchestration so we definitely need to Implement Multi-Threading for the CalculationEngine (on going...)
- Improve Test coverage
- Add QuoteCalculationEngine Mock
- Add Swagger in order to Call the API
- Define SLI, SLA with Stakeholders in terms of the chain performance (example: Rfq should be priced within 1 min for 95%tile of the Rfq)
- Improve the Exception Handling in case the Formatting of the Rfq is wrong or timeout
- Lock the RefPriceSource when ReferencePriceChanged is called
- implement Timeout for the RfqPricing in order to optimize ressources
- the dll can be deployed on Cloud services (VM or Azure services even Linux server)
- Add logs and structure log framework (i.e Serilog) in order to push logs and beats into ElasticSearch/grafana for easier Monitoring
- Also, this would help to keep trace of the Service acitivity and avoid persisting trace into Database which can slow down the process
- implement Health checks
- Create a Wiki
- Perform Demo
- Pair programming / Review
- Add Config File in order to avoid redeploying the service in case of any change
- implement Cache for the ReferencePriceSource if we want to optimize, with update in case of PriceUpdate
- many more ....
