# JD-Mapped Prep Plan: Microsoft Technical Delivery Lead (Cloud + AI)

Every block below maps to a specific line in the JD. If the JD doesn't ask for it, it's not here. Links only. Each block ends with a few questions you should be able to answer out loud without notes; if you can't, go back to the links.

**Total: 25 hours over 5 days.**

| # | Block | JD section | Hours |
|---|---|---|---|
| 1 | AI apps, search & RAG | AI Application Development | 3 |
| 2 | Agentic frameworks & Python | AI Application Development | 2.5 |
| 3 | Prompting, evaluation, reliability | AI Application Development | 2 |
| 4 | Responsible AI (mandatory) | AI Application Development | 2 |
| 5 | Security, compliance & Zero Trust | Security, Compliance & Zero Trust | 3 |
| 6 | Platforms, CI/CD, release, observability | Cloud Architecture, Platforms & DevOps | 3 |
| 7 | Architecture, full-stack & .NET | Full-Stack Application Development | 3.5 |
| 8 | Cloud data platforms | Full-Stack Application Development | 1.5 |
| 9 | Delivery leadership | Responsibilities + 5 yrs delivery leadership | 3 |
| 10 | Mock designs | Everything | 1.5 |

**Day plan**
- **Day 1 (5.5h):** Blocks 1, 2
- **Day 2 (5.5h):** Blocks 3, 4, 8
- **Day 3 (6h):** Blocks 5, 6
- **Day 4 (5h):** Block 7, first half of Block 9
- **Day 5 (3h):** Rest of Block 9, then Block 10

**If you run short on time, protect 1, 4, 5 and 9.** Responsible AI is marked mandatory in the JD, and delivery leadership is the one thing the panel can't check from your CV.

---

## ⚠️ Things that changed since this JD was written

Know these so you don't get caught out, and so you can mention them. It shows you're current.

- **AZ-204 retired on July 31, 2026.** The replacement is **AI-200** (Azure AI Cloud Developer Associate). [AI-200 study guide](https://learn.microsoft.com/credentials/certifications/resources/study-guides/ai-200)
- **AI-102 retired on June 30, 2026.** The replacement is **AI-103** (Developing AI Apps and Agents on Azure). [AI-103 study guide](https://learn.microsoft.com/credentials/certifications/resources/study-guides/ai-103)
- **Azure Database for MariaDB retired on September 19, 2025.** The migration path is MySQL Flexible Server. [Retirement notice](https://learn.microsoft.com/lifecycle/announcements/azure-products-retirement-september-2025)
- **"Cognitive Search" is now Azure AI Search**, and **"Azure AI Foundry" is now Microsoft Foundry.**
- **Semantic Kernel and AutoGen** have been merged into Microsoft Agent Framework.

The two new study guides also work as checklists. Skim the "skills measured" section of each one and flag anything you can't explain.

---

## Block 1: AI apps, search & RAG (3h)

> **JD:** *"Strong hands-on experience with Azure AI Foundry, Azure AI Search, Cognitive Search, Vector Search, and RAG patterns."*

**Foundry platform (45 min)**
- [ ] [Agents in Microsoft Foundry](https://learn.microsoft.com/azure/foundry/agents/overview): lifecycle, agent identity, private networking
- [ ] [Foundry capability reference](https://learn.microsoft.com/azure/foundry/concepts/capability-reference): one page mapping every feature
- [ ] [What is Foundry IQ](https://learn.microsoft.com/azure/foundry/agents/concepts/what-is-foundry-iq): the managed knowledge layer built on AI Search

**Azure AI Search, in depth (1h)**
- [ ] [Vector search overview](https://learn.microsoft.com/azure/search/vector-search-overview)
- [ ] [Hybrid search](https://learn.microsoft.com/azure/search/hybrid-search-overview): BM25 + HNSW merged with RRF
- [ ] [Semantic ranker](https://learn.microsoft.com/azure/search/semantic-search-overview)
- [ ] [Vector search quickstart](https://learn.microsoft.com/azure/search/search-get-started-vector): read the "understand the code" section and compare the hybrid results before and after semantic reranking
- [ ] [Choose an Azure service for vector search](https://learn.microsoft.com/azure/architecture/guide/technology-choices/vector-search): AI Search vs Cosmos DB vs PostgreSQL pgvector

**RAG design (1h 15 min)**
- [ ] [Design and develop a RAG solution](https://learn.microsoft.com/azure/architecture/ai-ml/guide/rag/rag-solution-design-and-evaluation-guide): read every phase this time (prep, chunking, enrichment, embeddings, retrieval, evaluation)
- [ ] [Agentic RAG](https://learn.microsoft.com/azure/architecture/ai-ml/guide/rag/rag-agentic): the latency and cost trade-offs are good interview material
- [ ] [Secure multitenant RAG](https://learn.microsoft.com/azure/architecture/ai-ml/guide/secure-multitenant-rag): data isolation, very relevant for banking customers
- [ ] [GPT-RAG accelerator](https://github.com/Azure/GPT-RAG): Microsoft's Zero Trust reference, which covers the JD's "reusable IP" line

**Be ready to answer**
- When is hybrid search better than pure vector search? Give an example with product codes or names.
- How would you choose a chunking strategy for 10,000 policy PDFs?
- When is agentic RAG worth the extra 5–10 seconds of latency?

## Block 2: Agentic frameworks & Python (2.5h)

> **JD:** *"Enterprise-grade LLM and agentic AI solutions using Semantic Kernel, LangChain, LangGraph, AutoGen, and developer copilots such as GitHub Copilot and Cursor."* and *"Advanced Python expertise in implementing RAG pipelines, vector workflows, agent orchestration, and AI evaluation frameworks."*

**Microsoft Agent Framework (1h)**
- [ ] [Agent Framework overview](https://learn.microsoft.com/agent-framework/overview/): why it replaced SK and AutoGen
- [ ] [Migration from Semantic Kernel](https://learn.microsoft.com/agent-framework/migration-guide/from-semantic-kernel/)
- [ ] [Migration from AutoGen](https://learn.microsoft.com/agent-framework/migration-guide/from-autogen/): GroupChat and the event-driven runtime, compared side by side
- [ ] [Agents in workflows (Python)](https://learn.microsoft.com/agent-framework/workflows/agents-in-workflows): the WorkflowBuilder graph model, easy to compare with LangGraph

**Orchestration patterns (45 min)**
- [ ] [AI agent orchestration patterns](https://learn.microsoft.com/azure/architecture/ai-ml/guide/ai-agent-design-patterns): sequential, concurrent, group chat, handoff, magentic
- [ ] [LangChain / LangGraph docs](https://docs.langchain.com): you know this already, so just have a clear answer on when you'd pick LangGraph over Agent Framework on an Azure engagement

**Developer copilots (45 min)**
- [ ] [GitHub Copilot docs](https://docs.github.com/copilot): look at agent mode, the coding agent, and custom instructions
- [ ] [Cursor docs](https://docs.cursor.com): rules and agent features
- [ ] [MCP with .NET](https://learn.microsoft.com/dotnet/ai/get-started-mcp): ties to your MCP/Copilot tooling work

**Be ready to answer**
- Walk through a multi-agent system you built. Why that orchestration pattern?
- How would you migrate a customer from Semantic Kernel to Agent Framework without a big-bang rewrite?
- How do you get consistent code quality out of Copilot across a 15-person team?

## Block 3: Prompting, evaluation, reliability (2h)

> **JD:** *"Prompt engineering, prompt optimization, evaluation frameworks, and reliability tuning to deliver safe, high-quality AI outputs."*

**Prompting & optimization (40 min)**
- [ ] [Prompt engineering techniques](https://learn.microsoft.com/azure/foundry/openai/concepts/prompt-engineering)
- [ ] [Prompt Optimizer in Foundry](https://learn.microsoft.com/azure/foundry/observability/how-to/prompt-optimizer)

**Evaluation (1h)**
- [ ] [Built-in evaluators](https://learn.microsoft.com/azure/foundry/concepts/built-in-evaluators)
- [ ] [RAG evaluators](https://learn.microsoft.com/azure/foundry/concepts/evaluation-evaluators/rag-evaluators): groundedness, relevance, retrieval
- [ ] [Agent evaluation](https://learn.microsoft.com/azure/foundry/observability/how-to/evaluate-agent): tool call accuracy, intent resolution, task adherence
- [ ] [Agent Framework evaluation (Python)](https://learn.microsoft.com/agent-framework/agents/evaluation): local checks, repetitions for non-determinism
- [ ] [Evaluations in CI/CD (GitHub Actions)](https://learn.microsoft.com/azure/foundry/how-to/evaluation-github-action)

**Reliability in production (20 min)**
- [ ] [Agent tracing](https://learn.microsoft.com/azure/foundry/observability/concepts/trace-agent-concept)
- [ ] [Continuous evaluation](https://learn.microsoft.com/azure/foundry/observability/how-to/cloud-evaluation)

**Be ready to answer**
- How do you build an eval dataset when the customer has no labelled data?
- What does an eval gate in a release pipeline look like, and what threshold blocks a deploy?
- How do you tell whether a quality drop comes from retrieval or from generation?

## Block 4: Responsible AI, mandatory (2h)

> **JD:** *"Strong understanding and application of Responsible AI principles, including safety, fairness, transparency, and governance (mandatory)."*

Cover one resource for each word in that line.

**Principles (20 min)**
- [ ] [Examine how Microsoft is committed to Responsible AI](https://learn.microsoft.com/training/modules/examine-microsoft-committed-responsible-ai/): the six principles, one unit each

**Safety (30 min)**
- [ ] [Azure AI Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/overview): prompt shields, groundedness detection
- [ ] [AI red teaming agent](https://learn.microsoft.com/azure/foundry/concepts/ai-red-teaming-agent)
- [ ] [Responsible AI practices for Azure OpenAI](https://learn.microsoft.com/azure/foundry/responsible-ai/openai/overview): the identify → measure → mitigate → operate cycle

**Transparency & fairness (30 min)**
- [ ] [Transparency note for Azure OpenAI](https://learn.microsoft.com/azure/foundry/responsible-ai/openai/transparency-note): read the limitations and best-practices sections
- [ ] [HAX Design Library](https://www.microsoft.com/en-us/haxtoolkit/library/): human-AI interaction guidelines (also covers the JD's "user-centered design" line)

**Governance (40 min)**
- [ ] [Responsible AI in Azure workloads (Well-Architected)](https://learn.microsoft.com/azure/well-architected/ai/responsible-ai)
- [ ] [CAF: AI governance process](https://learn.microsoft.com/azure/cloud-adoption-framework/ai/govern): built on NIST AI RMF
- [ ] [Purview DSPM for AI](https://learn.microsoft.com/purview/ai-microsoft-purview): keeping sensitive data out of prompts

**Be ready to answer**
- Give one concrete example per principle from your own projects. Write these six down.
- An AML agent flags a customer. How do you make that decision explainable and auditable?
- How would you set up RAI governance for a customer who has none?

## Block 5: Security, compliance & Zero Trust (3h)

> **JD:** *"Security-by-design... encryption, AuthN/AuthZ. Zero Trust, IAM, secure-by-default, threat modeling, compliance standards, DevSecOps. Least-privilege, assume-breach, micro-segmentation, continuous monitoring, SAST/DAST, secure CI/CD. Defender for Cloud, Threat Modeling Tool, Sentinel, Splunk."*

**Identity & encryption (45 min)**
- [ ] [Microsoft identity platform](https://learn.microsoft.com/entra/identity-platform/v2-overview): OAuth 2.0 / OIDC flows for AuthN and AuthZ
- [ ] [Managed identities](https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/overview)
- [ ] [Privileged Identity Management](https://learn.microsoft.com/entra/id-governance/privileged-identity-management/pim-configure): just-in-time access, the practical form of least privilege
- [ ] [Azure encryption overview](https://learn.microsoft.com/azure/security/fundamentals/encryption-overview): at rest, in transit, customer-managed keys

**Zero Trust (45 min)**
- [ ] [Zero Trust overview](https://learn.microsoft.com/security/zero-trust/zero-trust-overview)
- [ ] [Zero Trust segmentation in Azure](https://learn.microsoft.com/security/zero-trust/azure-networking-segmentation): assume breach, blast radius
- [ ] [Secure networks with Zero Trust](https://learn.microsoft.com/security/zero-trust/deploy/networks): the macro vs micro-segmentation section
- [ ] [Zero Trust for AI](https://learn.microsoft.com/security/zero-trust/workshop-zero-trust-ai-security)
- [ ] [Azure AI security best practices](https://learn.microsoft.com/azure/security/fundamentals/ai-security-best-practices)

**Threat modeling (30 min)**
- [ ] [Threat Modeling Tool](https://learn.microsoft.com/azure/security/develop/threat-modeling-tool)
- [ ] [STRIDE categories](https://learn.microsoft.com/azure/security/develop/threat-modeling-tool-threats)
- [ ] [Security guidance for LLMs](https://learn.microsoft.com/ai/playbook/technology-guidance/generative-ai/mlops-in-openai/security/security-recommend)

**DevSecOps & secure CI/CD (30 min)**
- [ ] [Enable DevSecOps with Azure and GitHub](https://learn.microsoft.com/devops/devsecops/enable-devsecops-azure-github)
- [ ] [MCSB: DevOps security controls](https://learn.microsoft.com/security/benchmark/azure/mcsb-devops-security): SAST (DS-4) and DAST (DS-5) with CIS/NIST/PCI mappings
- [ ] [DevSecOps on AKS](https://learn.microsoft.com/azure/architecture/guide/devsecops/devsecops-on-aks)

**Compliance & monitoring (30 min)**
- [ ] [Microsoft Cloud Security Benchmark](https://learn.microsoft.com/security/benchmark/azure/introduction)
- [ ] [Defender for Cloud](https://learn.microsoft.com/azure/defender-for-cloud/defender-for-cloud-introduction) and its [regulatory compliance dashboard](https://learn.microsoft.com/azure/defender-for-cloud/regulatory-compliance-dashboard)
- [ ] [Microsoft Sentinel](https://learn.microsoft.com/azure/sentinel/overview): SIEM/SOAR. For Splunk, be ready to say it's the SIEM many banks already run and how Sentinel would sit alongside it or replace it.

**Be ready to answer**
- Run STRIDE on a RAG chatbot. Name one threat per letter.
- What does "assume breach" change in how you design a microservice?
- Where do SAST, DAST, secret scanning and dependency scanning each sit in the pipeline?

## Block 6: Platforms, CI/CD, release, observability (3h)

> **JD:** *"Microservices and serverless using Kubernetes, Azure Functions, Service Fabric. CI/CD pipelines, automated testing, Blue/Green and Canary. Cloud monitoring and end-to-end telemetry."*

**Hosting (1h)**
- [ ] [Compute decision tree](https://learn.microsoft.com/azure/architecture/guide/technology-choices/compute-decision-tree)
- [ ] [AKS baseline architecture](https://learn.microsoft.com/azure/architecture/reference-architectures/containers/aks/baseline-aks)
- [ ] [Container Apps](https://learn.microsoft.com/azure/container-apps/overview) and [scaling with KEDA](https://learn.microsoft.com/azure/container-apps/scale-app)
- [ ] [Azure Functions](https://learn.microsoft.com/azure/azure-functions/functions-overview) and [Durable Functions](https://learn.microsoft.com/azure/azure-functions/durable/durable-functions-overview): orchestration, a natural way to implement Saga
- [ ] [Service Fabric overview](https://learn.microsoft.com/azure/service-fabric/service-fabric-overview): stateful services, and when it still beats AKS

**Release strategies (1h)**
- [ ] [Safe deployment practices](https://learn.microsoft.com/azure/well-architected/operational-excellence/safe-deployments)
- [ ] [Blue-green on AKS](https://learn.microsoft.com/azure/architecture/guide/aks/blue-green-deployment-for-aks)
- [ ] [Traffic splitting in Container Apps](https://learn.microsoft.com/azure/container-apps/traffic-splitting): canary with weights
- [ ] [App Service deployment slots](https://learn.microsoft.com/azure/app-service/deploy-staging-slots)
- [ ] [Feature flags in App Configuration](https://learn.microsoft.com/azure/azure-app-configuration/manage-feature-flags): percentage rollouts
- [ ] [Mission-critical deployment & testing](https://learn.microsoft.com/azure/well-architected/mission-critical/mission-critical-deployment-testing)

**CI/CD & testing (30 min)**
- [ ] [Azure Pipelines](https://learn.microsoft.com/azure/devops/pipelines/get-started/what-is-azure-pipelines)
- [ ] [Azure Load Testing](https://learn.microsoft.com/azure/load-testing/overview-what-is-azure-load-testing)
- [ ] [Bicep](https://learn.microsoft.com/azure/azure-resource-manager/bicep/overview) and [Azure Verified Modules](https://azure.github.io/Azure-Verified-Modules/): reusable IaC

**Observability (30 min)**
- [ ] [Enable OpenTelemetry with Azure Monitor](https://learn.microsoft.com/azure/azure-monitor/app/opentelemetry-enable)
- [ ] [Application Insights](https://learn.microsoft.com/azure/azure-monitor/app/app-insights-overview)
- [ ] [Monitoring and diagnostics best practices](https://learn.microsoft.com/azure/architecture/best-practices/monitoring)

**Be ready to answer**
- Blue/green vs canary vs feature flags: when do you use each?
- How would you roll back a bad model or prompt change, as opposed to a bad code change?
- Trace a single user request end to end across three services. What do you instrument?

## Block 7: Architecture, full-stack & .NET (3.5h)

> **JD:** *".NET (C#), Web APIs, Node.js... C#, JavaScript, TypeScript, Angular or React... Patterns and anti-patterns including MVC, CQRS, Saga... reusable frameworks for logging, security, resiliency, configuration... multi-threaded and parallel programming, high-throughput service design."*

**Patterns & anti-patterns (1h)**
- [ ] [Cloud design patterns catalog](https://learn.microsoft.com/azure/architecture/patterns/): CQRS, Saga, Compensating Transaction, Circuit Breaker, Bulkhead, Queue-Based Load Leveling
- [ ] [Performance antipatterns](https://learn.microsoft.com/azure/architecture/antipatterns/): Retry Storm, Chatty I/O, Noisy Neighbor, Synchronous I/O
- [ ] [Azure Well-Architected Framework](https://learn.microsoft.com/azure/well-architected/)
- [ ] [Transient fault handling](https://learn.microsoft.com/azure/architecture/best-practices/transient-faults)

**Reusable frameworks for cross-cutting concerns (45 min)**
- [ ] [.NET resilience (Polly-based)](https://learn.microsoft.com/dotnet/core/resilience/)
- [ ] [OpenTelemetry in .NET](https://learn.microsoft.com/dotnet/core/diagnostics/observability-with-otel): logging and tracing
- [ ] [Azure App Configuration](https://learn.microsoft.com/azure/azure-app-configuration/overview): config management, with Key Vault references for secrets
- [ ] [Aspire](https://aspire.dev/): service defaults as a shared framework

**Modern .NET (1h)**
- [ ] [What's new in .NET 10](https://learn.microsoft.com/dotnet/core/whats-new/dotnet-10/overview) and [C# 14](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-14)
- [ ] [What's new in ASP.NET Core 10](https://learn.microsoft.com/aspnet/core/release-notes/aspnetcore-10.0): minimal API validation, OpenAPI, SSE
- [ ] [.NET + AI ecosystem](https://learn.microsoft.com/dotnet/ai/dotnet-ai-ecosystem) and [Microsoft.Extensions.AI](https://learn.microsoft.com/dotnet/ai/microsoft-extensions-ai)

**Concurrency & throughput (30 min)**
- [ ] [Parallel programming in .NET](https://learn.microsoft.com/dotnet/standard/parallel-programming/)
- [ ] [System.Threading.Channels](https://learn.microsoft.com/dotnet/core/extensions/channels)

**Node / TypeScript / React (15 min, quick refresh)**
- [ ] [JavaScript on Azure](https://learn.microsoft.com/azure/developer/javascript/)
- [ ] [TypeScript handbook](https://www.typescriptlang.org/docs/handbook/intro.html) and [React docs](https://react.dev/learn): skim only if you're rusty

**Be ready to answer**
- Implement a Saga for a funds transfer across three services. Choreography or orchestration, and why?
- What's a Retry Storm, and how do Polly's circuit breaker and jitter prevent it?
- Design a service that has to process 50k messages/sec. Where do Channels, partitioning and backpressure come in?

## Block 8: Cloud data platforms (1.5h)

> **JD:** *"Azure SQL, Cosmos DB, Azure Database for PostgreSQL, MySQL, Azure SQL Managed Instance, and MariaDB."*

- [ ] [Choose a data store](https://learn.microsoft.com/azure/architecture/guide/technology-choices/data-store-overview)
- [ ] [Azure SQL Managed Instance](https://learn.microsoft.com/azure/azure-sql/managed-instance/sql-managed-instance-paas-overview): when MI instead of Azure SQL DB (lift-and-shift, SQL Agent, cross-database queries)
- [ ] [Cosmos DB partitioning](https://learn.microsoft.com/azure/cosmos-db/partitioning-overview) and [consistency levels](https://learn.microsoft.com/azure/cosmos-db/consistency-levels)
- [ ] [PostgreSQL Flexible Server](https://learn.microsoft.com/azure/postgresql/flexible-server/overview): pgvector for RAG
- [ ] [MySQL Flexible Server](https://learn.microsoft.com/azure/mysql/flexible-server/overview): also the migration target for MariaDB
- [ ] [MariaDB retirement notice](https://learn.microsoft.com/lifecycle/announcements/azure-products-retirement-september-2025)

**Be ready to answer**
- Pick a Cosmos DB partition key for a transactions table and justify it.
- Which consistency level for a banking balance vs a product catalog?
- A customer still runs MariaDB. What do you recommend?

## Block 9: Delivery leadership (3h)

> **JD Responsibilities:** strategy, user-centered design, estimating, dependencies, trade-offs, releases, risk and escalations, compliance, reusable IP, working with Sales on value propositions, thought leadership. Plus *"5+ years of customer-facing delivery leadership."*

**How Microsoft delivery teams work (1h)**
- [ ] [Code-With Engineering Playbook](https://microsoft.github.io/code-with-engineering-playbook/): engineering fundamentals, design reviews, agile delivery, automated testing
- [ ] [Failure mode analysis](https://learn.microsoft.com/azure/well-architected/reliability/failure-mode-analysis): a structured way to talk about technical risk

**Customer strategy & value (45 min)**
- [ ] [Cloud Adoption Framework overview](https://learn.microsoft.com/azure/cloud-adoption-framework/overview)
- [ ] [CAF: AI adoption strategy](https://learn.microsoft.com/azure/cloud-adoption-framework/ai/strategy): tying AI to business outcomes, the language Sales will use
- [ ] [CAF: AI agents adoption](https://learn.microsoft.com/azure/cloud-adoption-framework/ai-agents/)

**Write your STAR stories (1h 15 min)**

Each one maps to a JD responsibility line:
- [ ] **Technical risk caught early**: *"identify, assess, and manage technical risks"*
- [ ] **Trade-off you pushed back on**: *"making disciplined trade-offs"*
- [ ] **Escalation you handled**: *"handling escalations"*
- [ ] **Release you drove end to end**: *"driving successful releases"*
- [ ] **Estimate that was wrong, and how you recovered**: *"estimating effort, managing dependencies"*
- [ ] **Team you led or mentored**: *"leading engineering teams"*
- [ ] **Reusable asset you built that sped up delivery**: *"leveraging existing IP, reusable assets"*
- [ ] **Stakeholder or Sales conversation where you explained technical value**: *"articulate technical value propositions"*
- [ ] **Security or compliance requirement you met**: *"meet customer, regulatory, and governance requirements"*

Use the Text-to-SQL, AML agent and MCP tooling work for at least three of these. Keep each one to about 90 seconds spoken.

## Block 10: Mock designs (1.5h)

Do both out loud, 30 minutes each, then use the last 30 minutes to fix whatever you stumbled on.

**Mock A (AI):** *Design a secure, agentic RAG assistant for a bank's internal policy documents on Azure.*
- [ ] Foundry agents + Agent Framework orchestration pattern
- [ ] AI Search hybrid + semantic ranker, chunking choice
- [ ] Entra ID, managed identity, Key Vault, private endpoints
- [ ] Content Safety, prompt shields, STRIDE on the design
- [ ] Eval gates in CI/CD, continuous evaluation, tracing
- [ ] RAI: transparency (citations), governance (audit trail), human in the loop

**Mock B (modernization):** *A bank wants to move a monolithic .NET payments app to Azure microservices without downtime.*
- [ ] Hosting choice (AKS vs Container Apps vs Service Fabric) and why
- [ ] Saga for payment flow, Service Bus for commands, Event Grid for notifications
- [ ] Data split: Azure SQL MI first, then Cosmos DB where it fits
- [ ] Resilience with Polly, antipatterns to avoid
- [ ] Blue/green cutover, feature flags, rollback plan
- [ ] Zero Trust segmentation, DevSecOps pipeline, compliance evidence
- [ ] Delivery plan: phases, risks, dependencies, how you'd report status
