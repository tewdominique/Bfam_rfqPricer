# Bfam_rfqPricer
RfqPricerOrchestrator

## Backlog Next steps (prioritization): 
- I beleieve, the pricing time is the longest for the orchestration so we definitely need to Implement Multi-Threading for the CalculationEngine (Done)
- Add Swagger in order to Call the API (Done)
- Improve Test coverage (To do)
- Add QuoteCalculationEngine Mock (To do)
- implement Cache for the ReferencePriceSource if we want to optimize, with update in case of PriceUpdate (To do)
- reject the quote when the securityId is not in the referential (To do)
- Define SLI, SLA with Stakeholders in terms of the chain performance (example: Rfq should be priced within 1 min for 95%tile of the Rfq) (To do)
- Improve the Exception Handling in case the Formatting of the Rfq is wrong or timeout (To do)
- Lock the RefPriceSource when ReferencePriceChanged is called (To do)
- implement Timeout for the RfqPricing in order to optimize ressources (To do)
- the dll can be deployed on Cloud services (VM or Azure services even Linux server) (To do)
- Add logs and structure log framework (i.e Serilog) in order to push logs and beats into ElasticSearch/grafana for easier Monitoring (To do)
- Also, this would help to keep trace of the Service acitivity and avoid persisting trace into Database which can slow down the process 
- implement Health checks (To do)
- Create a Wiki
- Perform Demo (To do)
- Pair programming / Review (To do)
- Add Config File in order to avoid redeploying the service in case of any change (To do)

to continue....
