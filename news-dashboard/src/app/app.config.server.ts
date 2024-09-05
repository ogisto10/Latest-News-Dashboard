import { mergeApplicationConfig, ApplicationConfig } from '@angular/core';
import { provideServerRendering } from '@angular/platform-server';
import { appConfig } from './app.config';
import { NewsService } from './Service/news-service.service';

const serverConfig: ApplicationConfig = {
  providers: [
    provideServerRendering(),
    NewsService
  ]
};

export const config = mergeApplicationConfig(appConfig, serverConfig);
