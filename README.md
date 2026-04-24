# Game-Night-Web-App
# 🎮 Game Night Platform

A full-stack web application designed to make group games easy to play anywhere — no physical materials required.

## 📌 Overview

This project provides a digital platform where friends can play interactive games together while away from home. It eliminates the need for physical game components by bringing everything into a simple, accessible web experience.

## 🧱 Tech Stack

- **Frontend:** Angular 21  
- **Backend:** ASP.NET Core Web API (.NET 8 LTS)  
- **Hosting:** Microsoft Azure  
  - Azure App Service (Backend)  
  - Azure Static Web Apps (Frontend)

## 🚀 Features (Planned)

- Play interactive group-based games remotely  
- No physical items required  
- Simple and intuitive user interface  
- Scalable backend for handling multiple players  

## 🏗️ Project Structure
- `frontend/` → Angular application  
- `backend/` → ASP.NET Core Web API 

## ☁️ Deployment & CI/CD

This project uses **GitHub Actions for CI/CD** to automatically build and deploy both the frontend and backend to Azure.

### 🔁 Continuous Deployment Flow

#### Backend (ASP.NET Core API)
- Hosted on **Azure App Service**
- On every push to `main`:
  1. GitHub Actions builds the .NET project
  2. Publishes the compiled output
  3. Deploys directly to Azure App Service

#### Frontend (Angular)
- Hosted on **Azure Static Web Apps**
- On every push to `main`:
  1. Angular app is built from `/frontend/GameNight`
  2. Output is generated in `dist/GameNight/browser`
  3. Deployed automatically to Azure Static Web Apps

## 🎯 Purpose

This project was built to demonstrate full-stack development skills using a modern tech stack, including Angular and ASP.NET Core, while solving a real-world problem in a fun and engaging way.
